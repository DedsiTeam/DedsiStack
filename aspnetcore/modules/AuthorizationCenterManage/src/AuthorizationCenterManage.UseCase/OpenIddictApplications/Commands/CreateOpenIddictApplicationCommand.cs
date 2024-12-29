using AuthorizationCenterManage.OpenIddictApplications.Dtos;
using Dedsi.Ddd.CQRS.Commands;

namespace AuthorizationCenterManage.OpenIddictApplications.Commands;

/// <summary>
/// 创建 OpenIddictApplication
/// </summary>
/// <param name="InputDto"></param>
public record CreateOpenIddictApplicationCommand(CreateOpenIddictApplicationInputDto InputDto) : DedsiCommand<CreateOpenIddictApplicationResultDto>;
