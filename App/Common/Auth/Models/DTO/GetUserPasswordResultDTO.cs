namespace svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 로그인 결과 DTO
/// </summary>
public record GetUserPasswordResultDTO
{
    #region Fields
    /// <summary>
    /// 사용자 비밀번호
    /// </summary>
    public string? UserPassword { get; set; }
    #endregion
    
}
