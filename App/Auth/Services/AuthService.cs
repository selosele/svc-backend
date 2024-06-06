using svc.App.Auth.Models.DTO;
using svc.App.Auth.Repositories;

namespace svc.App.Auth.Services;

public class AuthService
{
    private readonly UserRepository _userRepository;
    public AuthService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// 로그인을 한다.
    /// </summary>
    public async Task<string> SignIn(SignInRequestDTO signInRequestDTO)
    {
        var user = await _userRepository.GetUser(signInRequestDTO);
        return user is not null ? "TEST TOKEN" : "";
    }
    
}

