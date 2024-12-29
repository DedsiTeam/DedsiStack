using Dedsi.Ddd.CQRS.Commands;

namespace AuthorizationCenterManage.OpenIddictApplications.Commands;

/// <summary>
/// 重置
/// </summary>
/// <param name="ClientId"></param>
public record ResetClientSecretCommand(string ClientId): DedsiCommand<string>;