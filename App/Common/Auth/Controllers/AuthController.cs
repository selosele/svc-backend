using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Models.DTO;
using Svc.App.Common.Auth.Services;

namespace Svc.App.Common.Auth.Controllers;

/// <summary>
/// 인증·인가 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/common/[controller]")]
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
    public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO loginRequestDTO)
    {
        var accessToken = await _authService.Login(loginRequestDTO);
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
    public async Task<ActionResult<bool>> FindUserAccount([FromBody] FindUserInfoRequestDTO findUserInfoRequestDTO)
        => Ok(await _authService.FindUserAccount(findUserInfoRequestDTO));

    /// <summary>
    /// 사용자의 비밀번호를 찾는다.
    /// </summary>
    [HttpPost("find-user-password")]
    public async Task<ActionResult<UserCertHistoryResponseDTO>> FindUserPassword([FromBody] FindUserInfoRequestDTO findUserInfoRequestDTO)
        => Ok(await _authService.FindUserPassword(findUserInfoRequestDTO));

    /// <summary>
    /// 사용자 본인인증 내역이 존재하는지 확인한다.
    /// </summary>
    [HttpGet("certs/{userAccount}")]
    public async Task<ActionResult<int>> CountUserCertHistory(string userAccount, [FromQuery] GetUserCertHistoryRequestDTO getUserCertHistoryRequestDTO)
        => Ok(await _authService.CountUserCertHistory(getUserCertHistoryRequestDTO));
    #endregion

}
