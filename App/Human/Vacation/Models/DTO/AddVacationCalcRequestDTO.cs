using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가 계산 설정 추가 요청 DTO
/// </summary>
public record AddVacationCalcRequestDTO : HttpRequestDTOBase
{
    #region [필드]
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
    /// 휴가 구분 코드 목록
    /// </summary>
    public IList<string>? VacationTypeCodes { get; set; }
    #endregion

}
