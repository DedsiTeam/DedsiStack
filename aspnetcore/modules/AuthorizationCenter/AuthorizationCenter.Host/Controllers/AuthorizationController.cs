using System.Security.Claims;
using Identity.Users.Queries;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using Volo.Abp.Security.Claims;

namespace AuthorizationCenter.Host.Controllers;

public class AuthorizationController(
    IOpenIddictApplicationManager applicationManager,
    IOpenIddictScopeManager scopeManager,
    IUserQuery userQuery) 
    : Controller
{
    [HttpPost("~/connect/token"), Produces("application/json")]
    public async Task<IActionResult> Exchange()
    {
        var request = HttpContext.GetOpenIddictServerRequest() ?? throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");
        
        if (request.IsClientCredentialsGrantType())
        {
            return await HandleClientCredentialsAsync(request);
        }

        if (request.IsPasswordGrantType())
        {
            return await HandlePasswordAsync(request);
        }

        throw new NotImplementedException("The specified grant is not implemented.");
    }

    /// <summary>
    /// 客户端授权模式
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    private async Task<IActionResult> HandleClientCredentialsAsync(OpenIddictRequest request)
    {
        var application = await applicationManager.FindByClientIdAsync(request.ClientId) ??
                          throw new InvalidOperationException("The application cannot be found.");

        var identity = new ClaimsIdentity(TokenValidationParameters.DefaultAuthenticationType, OpenIddictConstants.Claims.Name, OpenIddictConstants.Claims.Role);

        identity.SetClaim(OpenIddictConstants.Claims.Subject, await applicationManager.GetClientIdAsync(application));
        identity.SetClaim(OpenIddictConstants.Claims.Name, await applicationManager.GetDisplayNameAsync(application));

        identity.SetDestinations(static claim => claim.Type switch
        {
            OpenIddictConstants.Claims.Name when claim.Subject.HasScope(OpenIddictConstants.Permissions.Scopes.Profile)
                => [OpenIddictConstants.Destinations.AccessToken, OpenIddictConstants.Destinations.IdentityToken],
            _ => [OpenIddictConstants.Destinations.AccessToken]
        });

        return SignIn(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }

    /// <summary>
    /// Password 授权模式
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    private async Task<IActionResult> HandlePasswordAsync(OpenIddictRequest request)
    {
        var cancellationToken = HttpContext.RequestAborted;
        
        // 检查用户是否存在
        var user =
            await userQuery.GetByAccountAndPwdAsync(request.Username, request.Password, cancellationToken) ??
            throw new InvalidOperationException("The user could not be found.");

        var userId = user.Id.ToString();
        
        var application = await applicationManager.FindByClientIdAsync(request.ClientId, cancellationToken) ??
                          throw new InvalidOperationException("The application cannot be found.");

        var claimsIdentity = new ClaimsIdentity(TokenValidationParameters.DefaultAuthenticationType, OpenIddictConstants.Claims.Name, OpenIddictConstants.Claims.Role);
        claimsIdentity.AddClaim(OpenIddictConstants.Claims.Subject, userId);
        claimsIdentity.AddClaim(AbpClaimTypes.UserName, user.UserName);
        claimsIdentity.AddClaim(AbpClaimTypes.Email, user.Email);
        claimsIdentity.AddClaim(AbpClaimTypes.UserId, userId);
        claimsIdentity.SetScopes(request.GetScopes());
        claimsIdentity.SetResources(await scopeManager.ListResourcesAsync(claimsIdentity.GetScopes(), cancellationToken).ToListAsync());

        claimsIdentity.SetDestinations(static _ => [
            OpenIddictConstants.Destinations.IdentityToken,
            OpenIddictConstants.Destinations.AccessToken,
        ]);

        return SignIn(new ClaimsPrincipal(claimsIdentity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }
}