using System.ComponentModel.DataAnnotations;
using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Company.Models.DTO;

/// <summary>
/// 회사 추가 요청 DTO
/// </summary>
public record AddCompanyRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 사업자등록번호
    /// </summary>
    [Required]
    public string? RegistrationNo { get; set; }

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
    /// 회사 소재지
    /// </summary>
    public string? CompanyAddr { get; set; }

    /// <summary>
    /// 대표자명
    /// </summary>
    public string? CeoName { get; set; }
    #endregion

}
