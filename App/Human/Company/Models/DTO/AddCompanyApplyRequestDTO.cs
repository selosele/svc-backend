using System.ComponentModel.DataAnnotations;
using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Company.Models.DTO;

/// <summary>
/// 회사등록신청 추가 요청 DTO
/// </summary>
public record AddCompanyApplyRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 법인명
    /// </summary>
    public string? CorporateName { get; set; }

    /// <summary>
    /// 회사명
    /// </summary>
    [Required]
    public string? CompanyName { get; set; }

    /// <summary>
    /// 사업자등록번호
    /// </summary>
    public string? RegistrationNo { get; set; }

    /// <summary>
    /// 신청 내용
    /// </summary>
    public string? ApplyContent { get; set; }

    /// <summary>
    /// 신청 상태 코드
    /// </summary>
    public string? ApplyStateCode { get; set; }
    #endregion

}
