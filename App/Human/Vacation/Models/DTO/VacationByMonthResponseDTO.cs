namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 월별 휴가사용일수 응답 DTO
/// </summary>
public record VacationByMonthResponseDTO
{
    #region [필드]
    /// <summary>
    /// 월별 휴가사용일수
    /// </summary>
    public VacationByMonthResultDTO? VacationByMonth { get; set; }

    /// <summary>
    /// 월별 휴가사용일수 목록
    /// </summary>
    public IList<VacationByMonthResultDTO>? VacationByMonthList { get; set; }
    #endregion

}
