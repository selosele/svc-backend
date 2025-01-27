namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가 통계 응답 DTO
/// </summary>
public record VacationStatsResponseDTO
{
    #region [필드]
    /// <summary>
    /// 휴가일수정보
    /// </summary>
    public VacationCountInfoResultDTO? CountInfo { get; set; }

    /// <summary>
    /// 휴가 통계 목록
    /// </summary>
    public IList<VacationStatsResultDTO>? StatsList { get; set; }

    /// <summary>
    /// 휴가 목록
    /// </summary>
    public IList<VacationResponseDTO>? VacationList { get; set; }
    #endregion

}
