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
    #region [필드]
    private readonly AuthService _authService;
    private readonly CodeService _codeService;
    #endregion
    
    #region [생성자]
    public CodeController(
        AuthService authService,
        CodeService codeService
    ) {
        _authService = authService;
        _codeService = codeService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<CodeResponseDTO>>> ListCode()
    {
        var codeList = await _codeService.ListCode();
        return Ok(new CodeResponseDTO { CodeList = codeList });
    }

    /// <summary>
    /// 코드를 조회한다.
    /// </summary>
    [HttpGet("{codeId}")]
    [Authorize]
    public async Task<ActionResult<CodeResponseDTO>> GetCode(string codeId)
    {
        var code = await _codeService.GetCode(codeId);
        return Ok(new CodeResponseDTO { Code = code });
    }

    /// <summary>
    /// 코드를 추가한다.
    /// </summary>
    [HttpPost]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<CodeResponseDTO>> AddCode([FromBody] SaveCodeRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.CreaterId = user.UserId;

        var code = await _codeService.AddCode(dto);
        return Created(string.Empty, new CodeResponseDTO { Code = code });
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

        var code = await _codeService.UpdateCode(dto);
        return Ok(new CodeResponseDTO { Code = code });
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
