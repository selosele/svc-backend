using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가 조회 요청 DTO
/// </summary>
public record GetVacationRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 휴가 ID
    /// </summary>
    public int? VacationId { get; set; }

    /// <summary>
    /// 근무이력 ID
    /// </summary>
    public int? WorkHistoryId { get; set; }

    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 직원 ID
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// 휴가 시작일자
    /// </summary>
    public string? VacationStartYmd { get; set; }

    /// <summary>
    /// 휴가 종료일자
    /// </summary>
    public string? VacationEndYmd { get; set; }

    /// <summary>
    /// 휴가 상태 코드
    /// </summary>
    public string? VacationStatusCode { get; set; }
    #endregion

}
