using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using svc.App.Auth.Services;
using svc.App.Code.Models.DTO;
using svc.App.Code.Services;
using svc.App.Shared.Controllers;

namespace svc.App.Code.Controllers;

/// <summary>
/// 코드 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/[controller]s")]
public class CodeController : MyApiControllerBase<CodeController>
{
    private readonly CodeService _codeService;
    private readonly AuthService _authService;
    public CodeController(
        CodeService codeService,
        AuthService authService,
        ILogger<CodeController> logger,
        IMapper mapper
    ) : base(logger, mapper)
    {
        _codeService = codeService;
        _authService = authService;
    }

    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<CodeResponseDTO>>> ListCode()
    {
        var codeList = _mapper?.Map<List<CodeResponseDTO>>(await _codeService.ListCode());
        return Ok(codeList);
    }

}
