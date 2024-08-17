using svc.App.Shared.Models.DTO;

namespace svc.App.Human.Employee.Models.DTO;

/// <summary>
/// 직원 회사 조회 요청 DTO
/// </summary>
public record GetEmployeeCompanyRequestDTO  : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 직원 회사 ID
    /// </summary>
    public int? EmployeeCompanyId { get; set; }

    /// <summary>
    /// 직원 ID
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// 회사 ID
    /// </summary>
    public int? CompanyId { get; set; }
    #endregion

}
