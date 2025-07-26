namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가 조회 결과 DTO
/// </summary>
public record VacationResultDTO
{
    #region [필드]
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
    /// 휴가 구분 코드명
    /// </summary>
    public string? VacationTypeCodeName { get; set; }

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
    public double? VacationUseCount { get; set; }

    /// <summary>
    /// 휴가 상태 코드
    /// </summary>
    public string? VacationStatusCode { get; set; }

    /// <summary>
    /// 휴가 상태 코드명
    /// </summary>
    public string? VacationStatusCodeName { get; set; }

    /// <summary>
    /// 삭제 여부
    /// </summary>
    public string? DeleteYn { get; set; }
    #endregion

}
