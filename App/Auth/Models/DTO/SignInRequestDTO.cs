namespace svc.App.Auth.Models.DTO;

/// <summary>
/// 로그인 요청 DTO
/// </summary>
public class SignInRequestDTO
{
    /// <summary>
    /// 사용자 계정
    /// </summary>
    public string? UserAccount { get; set; }

    /// <summary>
    /// 사용자 비밀번호
    /// </summary>
    public string? UserPassword { get; set; }
    
}
