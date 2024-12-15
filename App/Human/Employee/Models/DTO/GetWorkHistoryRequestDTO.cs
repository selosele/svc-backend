using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Employee.Models.DTO;

/// <summary>
/// 근무이력 조회 요청 DTO
/// </summary>
public record GetWorkHistoryRequestDTO : HttpRequestDTOBase
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
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 회사 ID
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// 연차발생기준 코드
    /// </summary>
    public string? AnnualTypeCode { get; set; }

    /// <summary>
    /// 휴가 계산에 포함할 휴가 구분 코드 목록
    /// </summary>
    public IList<string>? VacationTypeCodes { get; set; }
    #endregion

}
