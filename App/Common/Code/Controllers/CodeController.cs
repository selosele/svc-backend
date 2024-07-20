using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using svc.App.Common.Code.Models.DTO;
using svc.App.Common.Code.Services;
using svc.App.Shared.Controllers;

namespace svc.App.Common.Code.Controllers;

/// <summary>
/// 코드 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/[controller]s")]
public class CodeController : MyApiControllerBase<CodeController>
{
    #region Fields
    private readonly CodeService _codeService;
    #endregion
    
    #region Constructor
    public CodeController(
        CodeService codeService,
        ILogger<CodeController> logger,
        IMapper mapper
    ) : base(logger, mapper)
    {
        _codeService = codeService;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<CodeResponseDTO>>> ListCode()
        => Ok(await _codeService.ListCode());

    /// <summary>
    /// 코드를 조회한다.
    /// </summary>
    [HttpGet("{codeId}")]
    [Authorize]
    public async Task<ActionResult<CodeResponseDTO>> GetCode(string codeId)
        => Ok(await _codeService.GetCode(codeId));
    #endregion

}
