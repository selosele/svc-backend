using Microsoft.AspNetCore.Mvc;
using svc.Models.Entities.Code;
using svc.Services.Code;

namespace svc.Controllers.Code;

[ApiController]
[Route("api/[controller]s")]
public class CodeController : ControllerBase
{
    private readonly ICodeService _codeService;
    public CodeController(ICodeService codeService)
    {
        _codeService = codeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CodeEntity>>> ListCode()
    {
        var CodeList = await _codeService.ListCode();
        return Ok(CodeList);
    }
}
