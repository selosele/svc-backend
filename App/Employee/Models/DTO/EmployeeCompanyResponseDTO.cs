namespace svc.App.Employee.Models.DTO;

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
    /// 회사 명
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// 회사 표출 명
    /// </summary>
    public string? CompanyDisplayName { get; set; }
    #endregion

}
