namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 월별 휴가사용일수 응답 DTO
/// </summary>
public record VacationByMonthResponseDTO
{
    #region [필드]
    /// <summary>
    /// 휴가 사용일수
    /// </summary>
    public double? VacationUseCount { get; set; }

    /// <summary>
    /// 휴가 사용 월
    /// </summary>
    public string? VacationMonth { get; set; }
    #endregion

}
