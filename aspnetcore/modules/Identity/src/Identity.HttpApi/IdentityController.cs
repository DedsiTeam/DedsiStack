using Dedsi.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Identity;

[ApiController]
[Area(IdentityDomainOptions.ApplicationName)]
[Route("api/Identity/[controller]/[action]")]
public abstract class IdentityController : DedsiControllerBase;