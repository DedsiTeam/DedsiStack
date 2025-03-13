using Dedsi.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace DedsiStack;

[ApiController]
[Area(DedsiStackDomainOptions.ApplicationName)]
[Route("api/DedsiStack/[controller]/[action]")]
// [ApiExplorerSettings(GroupName = DedsiStackDomainOptions.ApplicationName)]
public abstract class DedsiStackController : DedsiControllerBase;