using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using svc.App.Auth.Models.DTO;
using svc.App.Auth.Services;
using svc.App.Shared.Controllers;

namespace svc.App.Auth.Controllers;

/// <summary>
/// 인증·인가 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : MyApiControllerBase<AuthController>
{
    private readonly AuthService _authService;
    
    public AuthController(
        AuthService authService,
        ILogger<AuthController> logger,
        IMapper mapper
    ) : base(logger, mapper)
    {
        _authService = authService;
    }

    /// <summary>
    /// 로그인을 한다.
    /// </summary>
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO loginRequestDTO)
    {
        var accessToken = await _authService.Login(loginRequestDTO);
        return Ok(new LoginResponseDTO { AccessToken = accessToken });
    }

    /// <summary>
    /// 로그아웃을 한다.
    /// </summary>
    [HttpPost("logout")]
    public void Logout()
    {
        _authService.Logout();
    }

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    [HttpPost("users")]
    [Authorize(Roles = "ROLE_SYSTEM_ADMIN")]
    public async Task<ActionResult<UserResponseDTO>> AddUser([FromBody] AddUserRequestDTO addUserRequestDTO)
    {
        var user = _mapper?.Map<UserResponseDTO>(await _authService.AddUser(addUserRequestDTO));
        return Ok(user);
    }

}
