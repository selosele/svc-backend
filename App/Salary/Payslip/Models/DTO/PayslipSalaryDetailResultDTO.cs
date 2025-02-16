namespace Svc.App.Salary.Payslip.Models.DTO;

/// <summary>
/// 급여명세서 급여내역 상세 조회 결과 DTO
/// </summary>
public record PayslipSalaryDetailResultDTO
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
    public double? SalaryAmount { get; set; }

    /// <summary>
    /// 이전 달 급여내역 금액
    /// </summary>
    public double? PrevSalaryAmount { get; set; }

    /// <summary>
    /// 이전 달 급여내역 금액 차이
    /// </summary>
    public double? SalaryAmountCompare { get; set; }

    /// <summary>
    /// 이전 달 급여내역 금액 차이 퍼센테이지
    /// </summary>
    public double? SalaryAmountComparePercent { get; set; }
    #endregion

}
