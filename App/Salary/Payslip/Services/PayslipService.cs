using SmartSql.AOP;
using Svc.App.Salary.Payslip.Mappers;
using Svc.App.Salary.Payslip.Models.DTO;

namespace Svc.App.Salary.Payslip.Services;

/// <summary>
/// 급여명세서 서비스 클래스
/// </summary>
public class PayslipService
{
    #region [필드]
    private readonly PayslipMapper _payslipMapper;
    #endregion
    
    #region [생성자]
    public PayslipService(
        PayslipMapper payslipMapper
    )
    {
        _payslipMapper = payslipMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 급여명세서 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<PayslipResponseDTO>> ListPayslip(GetPayslipRequestDTO dto)
        => await _payslipMapper.ListPayslip(dto);
    #endregion
    
}

