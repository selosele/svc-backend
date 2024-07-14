namespace svc.App.Human.Employee.Models.DTO;

/// <summary>
/// 직원 회사 응답 DTO
/// </summary>
public record EmployeeCompanyResponseDTO
{
    #region Fields
    /// <summary>
    /// 회사 ID
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// 법인 명
    /// </summary>
    public string? CorporateName { get; set; }

    /// <summary>
    /// 회사 명
    /// </summary>
    public string? CompanyName { get; set; }
    #endregion

}
