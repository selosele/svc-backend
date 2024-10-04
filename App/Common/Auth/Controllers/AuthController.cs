using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Models.DTO;
using Svc.App.Common.Auth.Services;
using Svc.App.Shared.Utils;

namespace Svc.App.Common.Auth.Controllers;

/// <summary>
/// 인증·인가 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/co/[controller]")]
public class AuthController : ControllerBase
{
    #region Fields
    private readonly AuthService _authService;
    #endregion
    
    #region Constructor
    public AuthController(
        AuthService authService
    ) {
        _authService = authService;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 로그인을 한다.
    /// </summary>
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO dto)
    {
        if (dto.IsSuperLogin == "Y")
            return NotFound();

        var accessToken = await _authService.Login(dto);
        return Created(string.Empty, new LoginResponseDTO { AccessToken = accessToken });
    }

    /// <summary>
    /// 특정 사용자로 로그인한다.
    /// </summary>
    [HttpPost("superlogin")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<LoginResponseDTO>> SuperLogin([FromBody] LoginRequestDTO dto)
    {
        var accessToken = await _authService.Login(dto);
        return Created(string.Empty, new LoginResponseDTO { AccessToken = accessToken });
    }

    /// <summary>
    /// 로그아웃을 한다.
    /// </summary>
    [HttpPost("logout")]
    public void Logout()
        => _authService.Logout();

    /// <summary>
    /// 사용자의 아이디를 찾는다.
    /// </summary>
    [HttpPost("find-user-account")]
    public async Task<ActionResult<bool>> FindUserAccount([FromBody] FindUserInfoRequestDTO dto)
        => Created(string.Empty, await _authService.FindUserAccount(dto));

    /// <summary>
    /// 사용자의 비밀번호를 찾는다(인증코드 발송).
    /// </summary>
    [HttpPost("find-user-password1")]
    public async Task<ActionResult<UserCertHistoryResponseDTO>> FindUserPassword1([FromBody] FindUserInfoRequestDTO dto)
        => Created(string.Empty, await _authService.FindUserPassword1(dto));

    /// <summary>
    /// 사용자의 비밀번호를 찾는다(임시 비밀번호 발급).
    /// </summary>
    [HttpPost("find-user-password2")]
    public async Task<ActionResult<bool>> FindUserPassword2([FromBody] FindUserInfoRequestDTO dto)
        => Created(string.Empty, await _authService.FindUserPassword2(dto));

    /// <summary>
    /// 사용자 본인인증 내역이 존재하는지 확인한다.
    /// </summary>
    [HttpPost("certs/{userAccount}")]
    public async Task<ActionResult<int>> CountUserCertHistory(string userAccount, [FromBody] GetUserCertHistoryRequestDTO dto)
        => Created(string.Empty, await _authService.CountUserCertHistory(dto));
    #endregion

}
