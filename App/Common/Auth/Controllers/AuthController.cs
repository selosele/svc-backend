using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using svc.App.Common.Auth.Models.DTO;
using svc.App.Common.Auth.Services;
using svc.App.Shared.Controllers;
using svc.App.Shared.Utils;

namespace svc.App.Common.Auth.Controllers;

/// <summary>
/// 인증·인가 및 사용자, 권한 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : MyApiControllerBase<AuthController>
{
    #region Fields
    private readonly AuthService _authService;
    #endregion
    
    #region Constructor
    public AuthController(
        AuthService authService,
        ILogger<AuthController> logger,
        IMapper mapper
    ) : base(logger, mapper)
    {
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
    [Authorize(Roles = RoleUtil.SystemAdmin)]
    public async Task<ActionResult<List<UserResponseDTO>>> ListUser()
        => Ok(await _authService.ListUser());

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    [HttpGet("users/{userId}")]
    [Authorize(Roles = RoleUtil.SystemAdmin)]
    public async Task<ActionResult<UserResponseDTO>> GetUser(int userId)
        => Ok(await _authService.GetUser(new GetUserRequestDTO { UserId = userId }));

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    [HttpPost("users")]
    [Authorize(Roles = RoleUtil.SystemAdmin)]
    public async Task<ActionResult<UserResponseDTO>> AddUser([FromBody] AddUserRequestDTO addUserRequestDTO)
        => Created(string.Empty, await _authService.AddUser(addUserRequestDTO));

    /// <summary>
    /// 권한 목록을 조회한다.
    /// </summary>
    [HttpGet("roles")]
    [Authorize(Roles = RoleUtil.SystemAdmin)]
    public async Task<ActionResult<List<RoleResponseDTO>>> ListRole()
        => Ok(await _authService.ListRole());
    #endregion

}
