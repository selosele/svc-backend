using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 본인인증 내역 조회 요청 DTO
/// </summary>
public record GetUserCertHistoryRequestDTO : HttpRequestDTOBase
{
    #region Fields
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
    #endregion
    
}
