using System.ComponentModel.DataAnnotations;
using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 본인인증 이력 추가 요청 DTO
/// </summary>
public record AddUserCertHistoryRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 사용자 계정
    /// </summary>
    [Required]
    [MaxLength(20)]
    public string? UserAccount { get; set; }

    /// <summary>
    /// 휴대폰번호
    /// </summary>
    [MaxLength(20)]
    public string? PhoneNo { get; set; }

    /// <summary>
    /// 이메일주소
    /// </summary>
    [MaxLength(100)]
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
    #endregion

}
