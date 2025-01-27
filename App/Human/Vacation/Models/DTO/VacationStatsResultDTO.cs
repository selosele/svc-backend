namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가 조회 결과 DTO
/// </summary>
public record VacationStatsResultDTO
{
    #region [필드]
    /// <summary>
    /// 휴가 통계 ID
    /// </summary>
    public int? VacationStatsId { get; set; }

    /// <summary>
    /// 직원 ID
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// 근무이력 ID
    /// </summary>
    public int? WorkHistoryId { get; set; }

    /// <summary>
    /// 연도
    /// </summary>
    public string? YYYY { get; set; }

    /// <summary>
    /// 휴가 구분 코드
    /// </summary>
    public string? VacationTypeCode { get; set; }

    /// <summary>
    /// 휴가 구분 코드명
    /// </summary>
    public string? VacationTypeCodeName { get; set; }

    /// <summary>
    /// 휴가 사용 일수
    /// </summary>
    public int? VacationUseCount { get; set; }
    #endregion

}
