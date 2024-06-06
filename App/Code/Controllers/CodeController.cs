using Microsoft.AspNetCore.Mvc;
using svc.App.Code.Models.Entities;
using svc.App.Code.Services;
using svc.App.Shared.Controllers;

namespace svc.App.Code.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class CodeController : MyApiControllerBase<CodeController>
{
    private readonly CodeService _codeService;
    public CodeController
    (
        CodeService codeService,
        ILogger<CodeController> logger
    ) : base(logger)
    {
        _codeService = codeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CodeEntity>>> ListCode()
    {
        _logger?.LogInformation("TEST...");
        var codeList = await _codeService.ListCode();
        return Ok(codeList);
    }

}
