namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가 계산 설정 응답 DTO
/// </summary>
public record VacationCalcResponseDTO
{
    #region Fields
    /// <summary>
    /// 휴가 계산 설정 ID
    /// </summary>
    public int? VacationCalcId { get; set; }

    /// <summary>
    /// 근무이력 ID
    /// </summary>
    public int? WorkHistoryId { get; set; }

    /// <summary>
    /// 직원 ID
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// 연차발생기준코드
    /// </summary>
    public string? AnnualTypeCode { get; set; }

    /// <summary>
    /// 휴가 구분 코드
    /// </summary>
    public string? VacationTypeCode { get; set; }
    #endregion

}
