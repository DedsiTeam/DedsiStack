using AuthorizationCenterManage.OpenIddictApplications.Commands;
using AuthorizationCenterManage.OpenIddictApplications.Dtos;
using Dedsi.Ddd.CQRS.CommandHandlers;
using OpenIddict.Abstractions;
using Volo.Abp.Domain.Entities;

namespace AuthorizationCenterManage.OpenIddictApplications.CommandHandlers;

/// <summary>
/// 创建 OpenIddictApplication
/// </summary>
/// <param name="openIddictApplicationManager"></param>
public class CreateOpenIddictApplicationCommandHandler(IOpenIddictApplicationManager openIddictApplicationManager) 
    : DedsiCommandHandler<CreateOpenIddictApplicationCommand, CreateOpenIddictApplicationResultDto>
{
    /// <inheritdoc />
    public override async Task<CreateOpenIddictApplicationResultDto> Handle(CreateOpenIddictApplicationCommand command, CancellationToken cancellationToken)
    {
        var openIddictApplicationDescriptor = new OpenIddictApplicationDescriptor
        {
            ClientId = command.InputDto.ClientId,
            ClientSecret = GuidGenerator.Create().ToString().ToUpper(),
            DisplayName = command.InputDto.DisplayName,
            Permissions =
            {
                OpenIddictConstants.Permissions.Scopes.Address,
                OpenIddictConstants.Permissions.Scopes.Email,
                OpenIddictConstants.Permissions.Scopes.Phone,
                OpenIddictConstants.Permissions.Scopes.Profile,
                OpenIddictConstants.Permissions.Scopes.Roles,
            }
        };
        foreach (var permission in command.InputDto.Permissions)
        {
            openIddictApplicationDescriptor.Permissions.Add(permission);
        }

        foreach (var redirectUri in command.InputDto.RedirectUris)
        {
            openIddictApplicationDescriptor.RedirectUris.Add(redirectUri);
        }

        await openIddictApplicationManager.CreateAsync(openIddictApplicationDescriptor, cancellationToken);
        
        return new CreateOpenIddictApplicationResultDto()
        {
             ClientId = openIddictApplicationDescriptor.ClientId,
             ClientSecret = openIddictApplicationDescriptor.ClientSecret,
        };
    }
}