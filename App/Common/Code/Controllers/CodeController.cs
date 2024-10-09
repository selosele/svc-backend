using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Services;
using Svc.App.Common.Code.Models.DTO;
using Svc.App.Common.Code.Services;
using Svc.App.Shared.Utils;

namespace Svc.App.Common.Code.Controllers;

/// <summary>
/// 코드 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/co/codes")]
public class CodeController : ControllerBase
{
    #region Fields
    private readonly AuthService _authService;
    private readonly CodeService _codeService;
    #endregion
    
    #region Constructor
    public CodeController(
        AuthService authService,
        CodeService codeService
    ) {
        _authService = authService;
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

    /// <summary>
    /// 코드를 추가한다.
    /// </summary>
    [HttpPost]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<CodeResponseDTO>> AddCode([FromBody] SaveCodeRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.CreaterId = user.UserId;
        return Created(string.Empty, await _codeService.AddCode(dto));
    }

    /// <summary>
    /// 코드를 수정한다.
    /// </summary>
    [HttpPut("{codeId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<CodeResponseDTO>> UpdateUser(string codeId, [FromBody] SaveCodeRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.UpdaterId = user.UserId;
        return Ok(await _codeService.UpdateCode(dto));
    }

    /// <summary>
    /// 코드를 삭제한다.
    /// </summary>
    [HttpDelete("{codeId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult> RemoveCode(string codeId)
    {
        await _codeService.RemoveCode(codeId);
        return NoContent();
    }
    #endregion

}
