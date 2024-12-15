namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 본인인증 내역 응답 DTO
/// </summary>
public record UserCertHistoryResponseDTO
{
    #region [필드]
    /// <summary>
    /// 본인인증 내역 ID
    /// </summary>
    public int? CertHistoryId { get; set; }

    /// <summary>
    /// 사용자 계정
    /// </summary>
    public string? UserAccount { get; set; }

    /// <summary>
    /// 휴대폰번호
    /// </summary>
    public string? PhoneNo { get; set; }

    /// <summary>
    /// 이메일주소
    /// </summary>
    public string? EmailAddr { get; set; }

    /// <summary>
    /// 본인인증 코드
    /// </summary>
    public string? CertCode { get; set; }

    /// <summary>
    /// 본인인증 방법 코드
    /// </summary>
    public string? CertMethodCode { get; set; }

    /// <summary>
    /// 본인인증 구분 코드
    /// </summary>
    public string? CertTypeCode { get; set; }

    /// <summary>
    /// 유효시간(초)
    /// </summary>
    public int? ValidTime { get; set; }

    /// <summary>
    /// 등록일시
    /// </summary>
    public string? CreateDt { get; set; }
    #endregion
    
}
