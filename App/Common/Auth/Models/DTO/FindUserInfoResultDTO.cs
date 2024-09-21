namespace Svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 사용자 아이디/비밀번호 찾기 결과 DTO
/// </summary>
public record FindUserInfoResultDTO
{
    #region Fields
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 사용자 계정
    /// </summary>
    public string? UserAccount { get; set; }

    /// <summary>
    /// 직원명
    /// </summary>
    public string? EmployeeName { get; set; }

    /// <summary>
    /// 휴대폰번호
    /// </summary>
    public string? PhoneNo { get; set; }

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
