using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Models.DTO;
using Svc.App.Common.Auth.Services;
using Svc.App.Common.Mail.Models.DTO;
using Svc.App.Common.Mail.Services;
using Svc.App.Shared.Exceptions;
using Svc.App.Shared.Utils;

namespace Svc.App.Common.Auth.Controllers;

/// <summary>
/// 인증·인가 및 사용자, 권한 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/common/[controller]")]
public class AuthController : ControllerBase
{
    #region Fields
    private readonly AuthService _authService;
    private readonly MyMailService _mailService;
    #endregion
    
    #region Constructor
    public AuthController(
        AuthService authService,
        MyMailService mailService
    ) {
        _authService = authService;
        _mailService = mailService;
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
    /// 권한 목록을 조회한다.
    /// </summary>
    [HttpGet("roles")]
    [Authorize]
    public async Task<ActionResult<List<RoleResponseDTO>>> ListRole()
        => Ok(await _authService.ListRole());

    /// <summary>
    /// 사용자의 아이디를 찾는다.
    /// </summary>
    [HttpPost("find-user-account")]
    public async Task<ActionResult<int>> FindUserAccount([FromBody] FindUserAccountRequestDTO findUserAccountRequestDTO)
    {
        var foundUser = await _authService.GetUserFindAccount(findUserAccountRequestDTO)
            ?? throw new BizException("가입된 정보가 없습니다. 입력하신 정보를 다시 확인하세요.");

        var mailSend = await _mailService.Send(new SendMailDTO
        {
            To = foundUser?.EmailAddr,
            Subject = "아이디 확인 메일",
            Body = $@"
                <p>{foundUser?.EmployeeName}님 안녕하세요.</p><br>
                <p>회원님께서 조회하신 아이디는 다음과 같습니다.</p<br>

                <ul>
                    <li>아이디: {foundUser?.UserAccount}</li>
                    <li>계정 생성일시: {DateTime.Parse(foundUser?.CreateDt!):yyyy-MM-dd HH:mm:ss}</li>
                    <li>마지막 로그인 일시: {DateTime.Parse(foundUser?.LastLoginDt!):yyyy-MM-dd HH:mm:ss}</li>
                </ul>

                <p>아이디 확인 요청을 한 사람이 본인이 아닌 경우, 보안을 위해 시스템관리자(010-5594-3384)에게 연락해주시기 바랍니다.</p><br>
                <p>감사합니다.</p><br>
                <p>※ 본 메일은 <strong>발신전용</strong> 메일입니다. 회신이 불가능합니다.</p>
            "
        });
        return Ok(mailSend ? HttpStatusUtil.SUCCESS : HttpStatusUtil.FAIL);
    }
    #endregion

}
