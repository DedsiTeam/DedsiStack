using Dedsi.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Identity;

[ApiController]
[Area(IdentityDomainOptions.ApplicationName)]
[Route("api/Identity/[controller]/[action]")]
[ApiExplorerSettings(GroupName = IdentityDomainOptions.ApplicationName)]
public abstract class IdentityController : DedsiControllerBase;