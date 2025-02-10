using Svc.App.Shared.Models.DTO;

namespace Svc.App.Salary.Payslip.Models.DTO;

/// <summary>
/// 급여명세서 추가/수정 요청 DTO
/// </summary>
public record SavePayslipRequestDTO : HttpRequestDTOBase
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
    /// 급여명세서 비고
    /// </summary>
    public string? PayslipNote { get; set; }

    /// <summary>
    /// 직위 코드
    /// </summary>
    public string? RankCode { get; set; }

    /// <summary>
    /// 급여명세서 급여내역 상세
    /// </summary>
    public List<AddPayslipSalaryDetailRequestDTO>? PayslipSalaryDetailList { get; set; } = [];
    #endregion

}
