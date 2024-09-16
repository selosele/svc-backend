namespace Svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 아이디 찾기 응답 DTO
/// </summary>
public record FindUserAccountResponseDTO
{
    #region Fields
    /// <summary>
    /// 사용자 계정
    /// </summary>
    public string? UserAccount { get; set; }

    /// <summary>
    /// 직원명
    /// </summary>
    public string? EmployeeName { get; set; }

    /// <summary>
    /// 이메일주소
    /// </summary>
    public string? EmailAddr { get; set; }

    /// <summary>
    /// 등록일시
    /// </summary>
    public string? CreateDt { get; set; }

    /// <summary>
    /// 마지막 로그인 일시
    /// </summary>
    public string? LastLoginDt { get; set; }
    #endregion
    
}
