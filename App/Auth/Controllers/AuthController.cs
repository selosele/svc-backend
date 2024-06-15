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
    [HttpPost("sign-in")]
    public async Task<ActionResult<SignInResponseDTO>> SignIn([FromBody] SignInRequestDTO signInRequestDTO)
    {
        var accessToken = await _authService.SignIn(signInRequestDTO);
        return Ok(new SignInResponseDTO { AccessToken = accessToken });
    }

    /// <summary>
    /// 사용자를 추가한다.
    /// TODO: 시스템관리자만 api 호출할 수 있게 개선
    /// </summary>
    // [Authorize(Roles = "ROLE_ADMIN")]
    [HttpPost("users")]
    public async Task<ActionResult<UserResponseDTO>> AddUser([FromBody] AddUserRequestDTO addUserRequestDTO)
    {
        var user = _mapper?.Map<UserResponseDTO>(await _authService.AddUser(addUserRequestDTO));
        return Ok(user);
    }

}
