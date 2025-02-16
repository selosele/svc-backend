namespace Svc.App.Salary.Payslip.Models.DTO;

/// <summary>
/// 급여명세서 조회 결과 DTO
/// </summary>
public record PayslipResultDTO
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
    /// 직위 코드명
    /// </summary>
    public string? RankCodeName { get; set; }

    /// <summary>
    /// 입사일자
    /// </summary>
    public string? JoinYmd { get; set; }

    /// <summary>
    /// 회사명
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// 급여명세서 지급내역 총 금액
    /// </summary>
    public double? TotalAmountA00 { get; set; }

    /// <summary>
    /// 급여명세서 공제내역 총 금액
    /// </summary>
    public double? TotalAmountB00 { get; set; }

    /// <summary>
    /// 급여명세서 실지급액(지급내역-공제내역)
    /// </summary>
    public double? TotalAmount { get; set; }

    /// <summary>
    /// 이전 달 지급내역 총 금액
    /// </summary>
    public double? PrevTotalAmountA00 { get; set; }

    /// <summary>
    /// 이전 달 공제내역 총 금액
    /// </summary>
    public double? PrevTotalAmountB00 { get; set; }

    /// <summary>
    /// 이전 달 총 금액 차이
    /// </summary>
    public double? TotalAmountCompare { get; set; }

    /// <summary>
    /// 이전 달 총 금액 차이 퍼센테이지
    /// </summary>
    public double? TotalAmountComparePercent { get; set; }

    /// <summary>
    /// 이전 달 지급내역 금액 차이
    /// </summary>
    public double? TotalAmountCompareA00 { get; set; }

    /// <summary>
    /// 이전 달 공제내역 금액 차이
    /// </summary>
    public double? TotalAmountCompareB00 { get; set; }

    /// <summary>
    /// 이전 달 지급내역 금액 차이 퍼센테이지
    /// </summary>
    public double? TotalAmountComparePercentA00 { get; set; }

    /// <summary>
    /// 이전 달 공제내역 금액 차이 퍼센테이지
    /// </summary>
    public double? TotalAmountComparePercentB00 { get; set; }

    /// <summary>
    /// 이전/다음 급여명세서 flag
    /// </summary>
    public string? PrevNextFlag { get; set; }

    /// <summary>
    /// 급여명세서 급여내역 상세
    /// </summary>
    public IList<PayslipSalaryDetailResultDTO>? PayslipSalaryDetailList { get; set; }
    #endregion

}
