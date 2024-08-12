using svc.App.Shared.Models.DTO;

namespace svc.App.Human.Employee.Models.DTO;

/// <summary>
/// 직원 회사 수정 요청 DTO
/// </summary>
public record UpdateEmployeeCompanyRequestDTO : HttpRequestDTOBase
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
    /// 입사일자
    /// </summary>
    public string? JoinYmd { get; set; }

    /// <summary>
    /// 퇴사일자
    /// </summary>
    public string? QuitYmd { get; set; }
    #endregion

}