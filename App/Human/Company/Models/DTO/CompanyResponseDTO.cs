namespace Svc.App.Human.Company.Models.DTO;

/// <summary>
/// 회사 응답 DTO
/// </summary>
public record CompanyResponseDTO
{
    #region [필드]
    /// <summary>
    /// 회사
    /// </summary>
    public CompanyResultDTO? Company { get; set; }

    /// <summary>
    /// 회사 목록
    /// </summary>
    public IList<CompanyResultDTO>? CompanyList { get; set; }
    #endregion
    
}
