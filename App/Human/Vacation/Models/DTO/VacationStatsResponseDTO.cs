namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가 통계 응답 DTO
/// </summary>
public record VacationStatsResponseDTO
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
