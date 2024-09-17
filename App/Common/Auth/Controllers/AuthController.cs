using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Models.DTO;
using Svc.App.Common.Auth.Services;
using Svc.App.Shared.Utils;

namespace Svc.App.Common.Auth.Controllers;

/// <summary>
/// 인증·인가 및 사용자 컨트롤러 클래스
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
    /// 사용자 목록을 조회한다.
    /// </summary>
    [HttpGet("users")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<List<UserResponseDTO>>> ListUser([FromQuery] GetUserRequestDTO getUserRequestDTO)
        => Ok(await _authService.ListUser(getUserRequestDTO));

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    [HttpGet("users/{userId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<UserResponseDTO>> GetUser(int userId)
        => Ok(await _authService.GetUser(new GetUserRequestDTO { UserId = userId }));

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    [HttpPost("users")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<UserResponseDTO>> AddUser([FromBody] AddUserRequestDTO addUserRequestDTO)
        => Created(string.Empty, await _authService.AddUser(addUserRequestDTO));

    /// <summary>
    /// 사용자를 수정한다.
    /// </summary>
    [HttpPut("users/{userId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<UserResponseDTO>> UpdateUser(int userId, [FromBody] UpdateUserRequestDTO updateUserRequestDTO)
    {
        updateUserRequestDTO.UserId = userId;
        return Ok(await _authService.UpdateUser(updateUserRequestDTO));
    }

    /// <summary>
    /// 사용자 비밀번호를 변경한다.
    /// </summary>
    [HttpPut("users/{userId}/password")]
    [Authorize]
    public async Task<ActionResult<int>> UpdateUserPassword(int userId, [FromBody] UpdateUserPasswordRequestDTO updateUserPasswordRequestDTO)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);

        if (userId != myUserId)
            return NotFound();

        updateUserPasswordRequestDTO.UserId = myUserId;
        updateUserPasswordRequestDTO.UpdaterId = myUserId;

        return Ok(await _authService.UpdateUserPassword(updateUserPasswordRequestDTO));
    }

    /// <summary>
    /// 사용자를 삭제한다.
    /// </summary>
    [HttpDelete("users/{userId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult> RemoveUser(int userId)
    {
        await _authService.RemoveUser(userId);
        return NoContent();
    }

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
    public async Task<ActionResult<bool>> FindUserPassword([FromBody] FindUserInfoRequestDTO findUserInfoRequestDTO)
        => Ok(await _authService.FindUserPassword(findUserInfoRequestDTO));
    #endregion

}
