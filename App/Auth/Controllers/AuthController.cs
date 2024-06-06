using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using svc.App.Auth.Models.DTO;
using svc.App.Auth.Services;
using svc.App.Shared.Controllers;

namespace svc.App.Auth.Controllers;

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
        _logger?.LogInformation($"accessToken: {accessToken}");
        return Ok(new SignInResponseDTO { AccessToken = accessToken });
    }

}
