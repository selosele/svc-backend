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
    private readonly PayslipSalaryDetailMapper _payslipSalaryDetailMapper;
    #endregion
    
    #region [생성자]
    public PayslipService(
        PayslipMapper payslipMapper,
        PayslipSalaryDetailMapper payslipSalaryDetailMapper
    )
    {
        _payslipMapper = payslipMapper;
        _payslipSalaryDetailMapper = payslipSalaryDetailMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 급여명세서 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<PayslipResultDTO>> ListPayslip(GetPayslipRequestDTO dto)
        => await _payslipMapper.ListPayslip(dto);

    /// <summary>
    /// 이전/다음 급여명세서 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<PayslipResultDTO>> ListPrevNextPayslip(GetPayslipRequestDTO dto)
        => await _payslipMapper.ListPrevNextPayslip(dto);

    /// <summary>
    /// 급여명세서를 조회한다.
    /// </summary>
    [Transaction]
    public async Task<PayslipResultDTO> GetPayslip(int payslipId)
        => await _payslipMapper.GetPayslip(payslipId);

    /// <summary>
    /// 급여명세서를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<PayslipResultDTO> AddPayslip(SavePayslipRequestDTO dto)
    {
        // 1. 급여명세서를 추가한다.
        var payslipId = await _payslipMapper.AddPayslip(dto);

        // 2. 추가한 급여명세서를 조회한다.
        var payslip = await _payslipMapper.GetPayslip(payslipId);

        // 3. 급여명세서 급여내역 상세를 추가한다.
        foreach (var i in dto.PayslipSalaryDetailList!) {
            i.PayslipId = payslipId;
            i.CreaterId = dto.CreaterId;
        }
        await _payslipSalaryDetailMapper.AddPayslipSalaryDetail(dto.PayslipSalaryDetailList);

        // 4. 급여명세서 급여내역 상세 목록을 조회한다.
        payslip.PayslipSalaryDetailList = await _payslipSalaryDetailMapper.ListPayslipSalaryDetail(new GetPayslipRequestDTO
        {
            PayslipId = payslipId
        });

        // 5. 추가한 급여명세서를 반환한다.
        return payslip;
    }

    /// <summary>
    /// 급여명세서를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemovePayslip(int payslipId, int? updaterId)
        => await _payslipMapper.RemovePayslip(payslipId, updaterId);
    #endregion
    
}

