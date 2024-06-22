namespace svc.App.Auth.Models.DTO;

/// <summary>
/// 로그인 응답 DTO
/// </summary>
public record LoginResponseDTO
{
    /// <summary>
    /// 액세스 토큰
    /// </summary>
    public string? AccessToken { get; set; }
    
}
