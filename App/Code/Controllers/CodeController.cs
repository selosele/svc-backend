using Microsoft.AspNetCore.Mvc;
using svc.App.Code.Models.Entities;
using svc.App.Code.Services;

namespace svc.App.Code.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class CodeController : ControllerBase
{
    private readonly CodeService _codeService;
    public CodeController(CodeService codeService)
    {
        _codeService = codeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CodeEntity>>> ListCode()
    {
        var codeList = await _codeService.ListCode();
        return Ok(codeList);
    }

}
