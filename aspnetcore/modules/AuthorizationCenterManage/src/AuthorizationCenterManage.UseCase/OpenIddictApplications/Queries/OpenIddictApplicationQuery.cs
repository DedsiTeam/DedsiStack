using AuthorizationCenterManage.OpenIddictApplications.Dtos;
using Dedsi.Ddd.Domain.Queries;
using OpenIddict.Abstractions;

namespace AuthorizationCenterManage.OpenIddictApplications.Queries;

/// <summary>
/// 
/// </summary>
public interface IOpenIddictApplicationQuery : IDedsiQuery
{
    /// <summary>
    /// 获得 创建所需的数据
    /// </summary>
    /// <returns></returns>
    Task<OpenIddictViewDataDto> GetOpenIddictViewDataAsync();
}

/// <summary>
/// 
/// </summary>
public class OpenIddictApplicationQuery: IOpenIddictApplicationQuery
{
    /// <inheritdoc />
    public Task<OpenIddictViewDataDto> GetOpenIddictViewDataAsync()
    {
        return Task.FromResult(new OpenIddictViewDataDto()
        {
            Endpoints =
            [
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.Endpoints.Authorization),OpenIddictConstants.Permissions.Endpoints.Authorization),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.Endpoints.DeviceAuthorization),OpenIddictConstants.Permissions.Endpoints.DeviceAuthorization),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.Endpoints.EndSession),OpenIddictConstants.Permissions.Endpoints.EndSession),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.Endpoints.Introspection),OpenIddictConstants.Permissions.Endpoints.Introspection),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.Endpoints.Revocation),OpenIddictConstants.Permissions.Endpoints.Revocation),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.Endpoints.Token),OpenIddictConstants.Permissions.Endpoints.Token)
            ],
            GrantTypes =
            [
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.GrantTypes.ClientCredentials), OpenIddictConstants.Permissions.GrantTypes.ClientCredentials),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.GrantTypes.Password), OpenIddictConstants.Permissions.GrantTypes.Password),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.GrantTypes.AuthorizationCode), OpenIddictConstants.Permissions.GrantTypes.AuthorizationCode),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.GrantTypes.DeviceCode), OpenIddictConstants.Permissions.GrantTypes.DeviceCode),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.GrantTypes.Implicit), OpenIddictConstants.Permissions.GrantTypes.Implicit),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.GrantTypes.RefreshToken), OpenIddictConstants.Permissions.GrantTypes.RefreshToken),
            ],
            ResponseTypes = 
            [
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.ResponseTypes.Code), OpenIddictConstants.Permissions.ResponseTypes.Code),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.ResponseTypes.CodeIdToken), OpenIddictConstants.Permissions.ResponseTypes.CodeIdToken),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.ResponseTypes.CodeIdTokenToken), OpenIddictConstants.Permissions.ResponseTypes.CodeIdTokenToken),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.ResponseTypes.CodeToken), OpenIddictConstants.Permissions.ResponseTypes.CodeToken),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.ResponseTypes.IdToken), OpenIddictConstants.Permissions.ResponseTypes.IdToken),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.ResponseTypes.IdTokenToken), OpenIddictConstants.Permissions.ResponseTypes.IdTokenToken),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.ResponseTypes.None), OpenIddictConstants.Permissions.ResponseTypes.None),
                new OpenIddictSelectItemDto(nameof(OpenIddictConstants.Permissions.ResponseTypes.Token), OpenIddictConstants.Permissions.ResponseTypes.Token),
            ]
        });
    }
}