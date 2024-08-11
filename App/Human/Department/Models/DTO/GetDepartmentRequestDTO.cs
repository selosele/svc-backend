using svc.App.Shared.Models.DTO;

namespace svc.App.Human.Department.Models.DTO;

/// <summary>
/// 부서 조회 요청 DTO
/// </summary>
public record GetDepartmentRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 직원 ID
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// 회사 ID
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// 회사 ID
    /// </summary>
    public int? DepartmentId { get; set; }

    /// <summary>
    /// 회사별 조회 여부
    /// </summary>
    public string? GetByCompanyYn { get; set; }
    #endregion

}
