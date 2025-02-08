namespace Svc.App.Salary.Payslip.Models.DTO;

/// <summary>
/// 급여명세서 급여내역 상세 조회 결과 DTO
/// </summary>
public record PayslipDetailResultDTO
{
    #region [필드]
    /// <summary>
    /// 급여내역 상세 ID
    /// </summary>
    public int? SalaryId { get; set; }

    /// <summary>
    /// 급여명세서 ID
    /// </summary>
    public int? PayslipId { get; set; }

    /// <summary>
    /// 급여내역 구분 코드
    /// </summary>
    public string? SalaryTypeCode { get; set; }

    /// <summary>
    /// 급여내역 구분 코드명
    /// </summary>
    public string? SalaryTypeCodeName { get; set; }

    /// <summary>
    /// 급여내역 금액 코드
    /// </summary>
    public string? SalaryAmountCode { get; set; }

    /// <summary>
    /// 급여내역 금액 코드명
    /// </summary>
    public string? SalaryAmountCodeName { get; set; }

    /// <summary>
    /// 급여내역 금액
    /// </summary>
    public string? SalaryAmount { get; set; }
    #endregion

}
