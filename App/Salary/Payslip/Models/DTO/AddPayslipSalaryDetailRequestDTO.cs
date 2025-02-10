using Svc.App.Shared.Models.DTO;

namespace Svc.App.Salary.Payslip.Models.DTO;

/// <summary>
/// 급여명세서 급여내역 상세 추가 요청 DTO
/// </summary>
public record AddPayslipSalaryDetailRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 급여명세서 ID
    /// </summary>
    public int? PayslipId { get; set; }

    /// <summary>
    /// 급여내역 구분 코드
    /// </summary>
    public string? SalaryTypeCode { get; set; }

    /// <summary>
    /// 급여내역 금액 코드
    /// </summary>
    public string? SalaryAmountCode { get; set; }

    /// <summary>
    /// 급여내역 금액
    /// </summary>
    public string? SalaryAmount { get; set; }
    #endregion

}
