using Dedsi.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace DedsiAuthorization;

[ApiController]
[Area(DedsiAuthorizationDomainOptions.ApplicationName)]
[Route("api/DedsiAuthorization/[controller]/[action]")]
// [ApiExplorerSettings(GroupName = DedsiAuthorizationDomainOptions.ApplicationName)]
public abstract class DedsiAuthorizationController : DedsiControllerBase;