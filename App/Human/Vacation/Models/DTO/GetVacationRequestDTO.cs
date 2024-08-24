using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가 조회 요청 DTO
/// </summary>
public record GetVacationRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 휴가 ID
    /// </summary>
    public int? VacationId { get; set; }

    /// <summary>
    /// 직원 회사 ID
    /// </summary>
    public int? EmployeeCompanyId { get; set; }
    #endregion

}
