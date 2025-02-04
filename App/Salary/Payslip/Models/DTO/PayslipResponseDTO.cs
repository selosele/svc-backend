namespace Svc.App.Salary.Payslip.Models.DTO;

/// <summary>
/// 급여명세서 응답 DTO
/// </summary>
public record PayslipResponseDTO
{
    #region [필드]
    /// <summary>
    /// 급여명세서 ID
    /// </summary>
    public int? PayslipId { get; set; }

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
    /// 급여명세서 지급내역 총 금액
    /// </summary>
    public string? TotalAmountA00 { get; set; }

    /// <summary>
    /// 급여명세서 공제내역 총 금액
    /// </summary>
    public string? TotalAmountB00 { get; set; }

    /// <summary>
    /// 급여명세서 실지급액(지급내역-공제내역)
    /// </summary>
    public string? TotalAmount { get; set; }
    #endregion

}
