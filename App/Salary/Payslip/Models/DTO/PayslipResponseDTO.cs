namespace Svc.App.Salary.Payslip.Models.DTO;

/// <summary>
/// 급여명세서 응답 DTO
/// </summary>
public record PayslipResponseDTO
{
    #region [필드]
    /// <summary>
    /// 급여명세서
    /// </summary>
    public PayslipResultDTO? Payslip { get; set; }

    /// <summary>
    /// 급여명세서 급여내역 상세
    /// </summary>
    public PayslipDetailResponseDTO? PayslipDetail { get; set; }

    /// <summary>
    /// 급여명세서 목록
    /// </summary>
    public IList<PayslipResultDTO>? PayslipList { get; set; }
    #endregion

}
