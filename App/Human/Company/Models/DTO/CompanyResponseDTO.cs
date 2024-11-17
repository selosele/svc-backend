namespace Svc.App.Human.Company.Models.DTO;

/// <summary>
/// 회사 응답 DTO
/// </summary>
public record CompanyResponseDTO
{
    #region Fields
    /// <summary>
    /// 회사 ID
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// 사업자등록번호
    /// </summary>
    public string? RegistrationNo { get; set; }
    
    /// <summary>
    /// 법인명
    /// </summary>
    public string? CorporateName { get; set; }
    
    /// <summary>
    /// 회사명
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// 회사 소재지
    /// </summary>
    public string? CompanyAddr { get; set; }

    /// <summary>
    /// 대표자명
    /// </summary>
    public string? CeoName { get; set; }
    
    /// <summary>
    /// 삭제 여부
    /// </summary>
    public string? DeleteYn { get; set; }
    #endregion
    
}
