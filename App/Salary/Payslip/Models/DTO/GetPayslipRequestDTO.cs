using Svc.App.Shared.Models.DTO;

namespace Svc.App.Salary.Payslip.Models.DTO;

/// <summary>
/// 급여명세서 조회 요청 DTO
/// </summary>
public record GetPayslipRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 급여명세서 ID
    /// </summary>
    public int? PayslipId { get; set; }

    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 직원 ID
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// 근무이력 ID
    /// </summary>
    public int? WorkHistoryId { get; set; }

    /// <summary>
    /// 급여명세서 지급일자
    /// </summary>
    public string? PayslipPaymentYmd { get; set; }

    /// <summary>
    /// 급여명세서 지급 연도
    /// </summary>
    public string? PayslipPaymentYYYY { get; set; }

    /// <summary>
    /// 급여명세서 지급 월
    /// </summary>
    public string? PayslipPaymentMM { get; set; }

    /// <summary>
    /// 최신 급여명세서 조회 여부 (Y/N)
    /// </summary>
    public string? IsGetCurrent { get; set; }
    #endregion

}
