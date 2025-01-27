namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가일수정보 조회 결과 DTO
/// </summary>
public record VacationCountInfoResultDTO
{
    #region [필드]
    /// <summary>
    /// 총 휴가 일수
    /// </summary>
    public int? VacationTotalCount { get; set; }

    /// <summary>
    /// 휴가 사용 일수
    /// </summary>
    public int? VacationUseCount { get; set; }

    /// <summary>
    /// 휴가 잔여 일수
    /// </summary>
    public int? VacationRemainCount { get; set; }
    #endregion

}
