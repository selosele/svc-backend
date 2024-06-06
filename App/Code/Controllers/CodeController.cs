using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using svc.App.Code.Models.DTO;
using svc.App.Code.Services;
using svc.App.Shared.Controllers;

namespace svc.App.Code.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class CodeController : MyApiControllerBase<CodeController>
{
    private readonly CodeService _codeService;
    public CodeController(
        CodeService codeService,
        ILogger<CodeController> logger,
        IMapper mapper
    ) : base(logger, mapper)
    {
        _codeService = codeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CodeResponseDTO>>> ListCode()
    {
        var codeList = _mapper?.Map<List<CodeResponseDTO>>(await _codeService.ListCode());
        _logger?.LogInformation($"코드 목록 조회: {codeList?.Count}건 조회됨");
        return Ok(codeList);
    }

}
