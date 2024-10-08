using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Company.Models.DTO;

/// <summary>
/// 회사 조회 요청 DTO
/// </summary>
public record GetCompanyRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 회사 ID
    /// </summary>
    public int? CompanyId { get; set; }
    
    /// <summary>
    /// 법인명
    /// </summary>
    public string? CorporateName { get; set; }
    
    /// <summary>
    /// 회사명
    /// </summary>
    public string? CompanyName { get; set; }
    
    /// <summary>
    /// 사업자등록번호
    /// </summary>
    public string? RegistrationNo { get; set; }
    #endregion
    
}
