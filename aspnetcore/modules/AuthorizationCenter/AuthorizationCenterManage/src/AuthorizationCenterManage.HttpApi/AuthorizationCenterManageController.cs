using Dedsi.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationCenterManage;

[ApiController]
[Area(AuthorizationCenterManageDomainOptions.ApplicationName)]
[Route("api/AuthorizationCenterManage/[controller]/[action]")]
[ApiExplorerSettings(GroupName = AuthorizationCenterManageDomainOptions.ApplicationName)]
public abstract class AuthorizationCenterManageController : DedsiControllerBase;