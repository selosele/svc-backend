using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Company.Models.DTO;

/// <summary>
/// 회사등록신청 조회 요청 DTO
/// </summary>
public record GetCompanyApplyRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 회사등록신청 ID
    /// </summary>
    public int? CompanyApplyId { get; set; }
    
    /// <summary>
    /// 사업자등록번호
    /// </summary>
    public string? RegistrationNo { get; set; }
    
    /// <summary>
    /// 신청자 ID
    /// </summary>
    public int? ApplicantId { get; set; }
    #endregion
    
}
