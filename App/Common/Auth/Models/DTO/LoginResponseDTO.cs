namespace svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 로그인 응답 DTO
/// </summary>
public record LoginResponseDTO
{
    #region Fields
    /// <summary>
    /// 액세스 토큰
    /// </summary>
    public string? AccessToken { get; set; }
    #endregion
    
}
