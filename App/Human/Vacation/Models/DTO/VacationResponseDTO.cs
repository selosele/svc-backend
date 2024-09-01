namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가 응답 DTO
/// </summary>
public record VacationResponseDTO
{
    #region Fields
    /// <summary>
    /// 휴가 ID
    /// </summary>
    public int? VacationId { get; set; }

    /// <summary>
    /// 직원 ID
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// 근무이력 ID
    /// </summary>
    public int? WorkHistoryId { get; set; }

    /// <summary>
    /// 휴가 구분 코드
    /// </summary>
    public string? VacationTypeCode { get; set; }

    /// <summary>
    /// 휴가 내용
    /// </summary>
    public string? VacationContent { get; set; }

    /// <summary>
    /// 휴가 시작일자
    /// </summary>
    public string? VacationStartYmd { get; set; }

    /// <summary>
    /// 휴가 종료일자
    /// </summary>
    public string? VacationEndYmd { get; set; }

    /// <summary>
    /// 휴가 사용일수
    /// </summary>
    public int? VacationDiff { get; set; }

    /// <summary>
    /// 삭제 여부
    /// </summary>
    public string? DeleteYn { get; set; }
    #endregion

}
