using Dedsi.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceCenter;

[ApiController]
[Area(MicroserviceCenterDomainOptions.ApplicationName)]
[Route("api/MicroserviceCenter/[controller]/[action]")]
[ApiExplorerSettings(GroupName = MicroserviceCenterDomainOptions.ApplicationName)]
public abstract class MicroserviceCenterController : DedsiControllerBase;