using System.Security.Claims;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

namespace AuthorizationCenter.Host.Controllers;

public class AuthorizationController(IOpenIddictApplicationManager applicationManager) : Controller
{
    [HttpPost("~/connect/token"), Produces("application/json")]
    public async Task<IActionResult> Exchange()
    {
        var request = HttpContext.GetOpenIddictServerRequest();
        if (request == null)
        {
            throw new InvalidOperationException("request is null.");
        }
        if (request.IsClientCredentialsGrantType())
        {
            return await ClientCredential(request);
        }

        if (request.IsPasswordGrantType())
        {
            
        }
        

        throw new NotImplementedException("The specified grant is not implemented.");
    }

    /// <summary>
    /// 客户端登录
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    private async Task<IActionResult> ClientCredential(OpenIddictRequest? request)
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
}