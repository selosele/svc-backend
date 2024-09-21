using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Models.DTO;
using Svc.App.Common.Auth.Services;
using Svc.App.Shared.Utils;

namespace Svc.App.Common.Auth.Controllers;

/// <summary>
/// 사용자 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/common/users")]
public class UserController : ControllerBase
{
    #region Fields
    private readonly AuthService _authService;
    private readonly UserService _userService;
    #endregion
    
    #region Constructor
    public UserController(
        AuthService authService,
        UserService userService
    ) {
        _authService = authService;
        _userService = userService;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 사용자 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<List<UserResponseDTO>>> ListUser([FromQuery] GetUserRequestDTO getUserRequestDTO)
        => Ok(await _userService.ListUser(getUserRequestDTO));

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    [HttpGet("{userId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<UserResponseDTO>> GetUser(int userId)
        => Ok(await _userService.GetUser(new GetUserRequestDTO { UserId = userId }));

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    [HttpPost]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<UserResponseDTO>> AddUser([FromBody] AddUserRequestDTO addUserRequestDTO)
        => Created(string.Empty, await _userService.AddUser(addUserRequestDTO));

    /// <summary>
    /// 사용자를 수정한다.
    /// </summary>
    [HttpPut("{userId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<UserResponseDTO>> UpdateUser(int userId, [FromBody] UpdateUserRequestDTO updateUserRequestDTO)
    {
        updateUserRequestDTO.UserId = userId;
        return Ok(await _userService.UpdateUser(updateUserRequestDTO));
    }

    /// <summary>
    /// 사용자 비밀번호를 변경한다.
    /// </summary>
    [HttpPut("{userId}/password")]
    [Authorize]
    public async Task<ActionResult<int>> UpdateUserPassword(int userId, [FromBody] UpdateUserPasswordRequestDTO updateUserPasswordRequestDTO)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);

        if (userId != myUserId)
            return NotFound();

        updateUserPasswordRequestDTO.UserId = myUserId;
        updateUserPasswordRequestDTO.UpdaterId = myUserId;

        return Ok(await _userService.UpdateUserPassword(updateUserPasswordRequestDTO));
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
