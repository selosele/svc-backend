using svc.App.Shared.Models.DTO;

namespace svc.App.Human.Department.Models.DTO;

/// <summary>
/// 부서 수정 요청 DTO
/// </summary>
public record UpdateDepartmentRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 부서 ID
    /// </summary>
    public int? DepartmentId { get; set; }

    /// <summary>
    /// 직원 회사 ID
    /// </summary>
    public int? EmployeeCompanyId { get; set; }

    /// <summary>
    /// 회사 ID
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// 직원 ID
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// 직급 코드
    /// </summary>
    public string? RankCode { get; set; }

    /// <summary>
    /// 직책 코드
    /// </summary>
    public string? JobTitleCode { get; set; }
    #endregion

}
