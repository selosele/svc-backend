namespace svc.App.Human.Employee.Models.DTO;

/// <summary>
/// 직원 회사 응답 DTO
/// </summary>
public record EmployeeCompanyResponseDTO
{
    #region Fields
    /// <summary>
    /// 직원 회사 ID
    /// </summary>
    public int? EmployeeCompanyId { get; set; }

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
    /// 입사일자
    /// </summary>
    public string? JoinYmd { get; set; }

    /// <summary>
    /// 퇴사일자
    /// </summary>
    public string? QuitYmd { get; set; }
    #endregion

}
