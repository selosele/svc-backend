using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 월별 휴가사용일수 조회 요청 DTO
/// </summary>
public record GetVacationByMonthRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 근무이력 ID
    /// </summary>
    public int? WorkHistoryId { get; set; }

    /// <summary>
    /// 휴가사용연도
    /// </summary>
    public string? YYYY { get; set; }

    /// <summary>
    /// 휴가 구분 코드
    /// </summary>
    public string? VacationTypeCode { get; set; }
    #endregion

}
