using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가 추가/수정 요청 DTO
/// </summary>
public record SaveVacationRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 휴가 ID
    /// </summary>
    public int? VacationId { get; set; }

    /// <summary>
    /// 휴가 ID
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
    #endregion

}
