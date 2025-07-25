using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.User.Models.DTO;
using Svc.App.Common.Auth.Services;
using Svc.App.Common.User.Services;
using Svc.App.Shared.Utils;

namespace Svc.App.Common.User.Controllers;

/// <summary>
/// 사용자 API
/// </summary>
[ApiController]
[Route("api/co/users")]
public class UserController(
    AuthService authService,
    UserService userService
    ) : ControllerBase
{
    #region [필드]
    private readonly AuthService _authService = authService;
    private readonly UserService _userService = userService;
    #endregion

    #region [메서드]
    /// <summary>
    /// 사용자 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<UserResponseDTO>> ListUser([FromQuery] GetUserRequestDTO dto)
    {
        var userList = await _userService.ListUser(dto);
        return Ok(new UserResponseDTO { UserList = userList });
    }

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    [HttpGet("{userId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<UserResponseDTO>> GetUser(int userId)
    {
        var user = await _userService.GetUser(new GetUserRequestDTO { UserId = userId });
        return Ok(new UserResponseDTO { User = user });
    }

    /// <summary>
    /// 사용자 설정을 조회한다.
    /// </summary>
    [HttpGet("{userId}/setups")]
    [Authorize]
    public async Task<ActionResult<UserSetupResponseDTO>> GetUserSetup(int userId)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;

        if (userId != myUserId)
            return NotFound();

        var userSetup = await _userService.GetUserSetup(new GetUserSetupRequestDTO { UserId = userId });
        return Ok(new UserSetupResponseDTO { UserSetup = userSetup });
    }

    /// <summary>
    /// 사용자 설정을 추가한다.
    /// </summary>
    [HttpPost("{userId}/setups")]
    [Authorize]
    public async Task<ActionResult<UserSetupResponseDTO>> AddUserSetup(int userId, [FromBody] AddUserSetupRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;

        if (userId != myUserId)
            return NotFound();

        dto.UserId = myUserId;
        dto.CreaterId = myUserId;

        var userSetup = await _userService.AddUserSetup(dto);
        return Created(string.Empty, new UserSetupResponseDTO { UserSetup = userSetup });
    }

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    [HttpPost]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<UserResponseDTO>> AddUser([FromBody] AddUserRequestDTO dto)
    {
        var user = await _userService.AddUser(dto);
        return Created(string.Empty, new UserResponseDTO { User = user});
    }

    /// <summary>
    /// 사용자를 수정한다.
    /// </summary>
    [HttpPut("{userId}")]
    [Authorize]
    public async Task<ActionResult<UserResponseDTO>> UpdateUser(int userId, [FromBody] UpdateUserRequestDTO dto)
    {
        dto.UserId = userId;
        
        var user = await _userService.UpdateUser(dto);
        return Ok(new UserResponseDTO { User = user});
    }

    /// <summary>
    /// 사용자 비밀번호를 변경한다.
    /// </summary>
    [HttpPut("{userId}/password")]
    [Authorize]
    public async Task<ActionResult<int>> UpdateUserPassword(int userId, [FromBody] UpdateUserPasswordRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;

        if (userId != myUserId)
            return NotFound();

        dto.UserId = myUserId;
        dto.UpdaterId = myUserId;

        return Ok(await _userService.UpdateUserPassword(dto));
    }

    /// <summary>
    /// 사용자를 삭제한다.
    /// </summary>
    [HttpDelete("{userId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult> RemoveUser(int userId)
    {
        await _userService.RemoveUser(userId);
        return NoContent();
    }
    #endregion

}
