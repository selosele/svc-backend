using SmartSql.AOP;
using Svc.App.Salary.Payslip.Mappers;
using Svc.App.Salary.Payslip.Models.DTO;
using Svc.App.Shared.Exceptions;

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
    {
        var payslip = await _payslipMapper.GetPayslip(payslipId);
        payslip.PayslipSalaryDetailList = await _payslipSalaryDetailMapper.ListPayslipSalaryDetail(new GetPayslipRequestDTO
        {
            PayslipId = payslipId
        });

        return payslip;
    }

    /// <summary>
    /// 급여명세서를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<PayslipResultDTO> AddPayslip(SavePayslipRequestDTO dto)
    {
        // 1. 지급월에 해당하는 급여명세서가 있는지 조회힌다.
        var count = await _payslipMapper.CountPayslip(new GetPayslipRequestDTO
        {
            WorkHistoryId = dto.WorkHistoryId,
            PayslipPaymentYmd = dto.PayslipPaymentYmd
        });

        if (count > 0)
        {
            var YYYYMM = Convert.ToDateTime(dto.PayslipPaymentYmd).ToString("yyyy년 MM월");
            throw new BizException($"{YYYYMM}에 이미 등록된 급여명세서가 있어요.");
        }

        // 2. 급여명세서를 추가한다.
        var payslipId = await _payslipMapper.AddPayslip(dto);

        // 3. 추가한 급여명세서를 조회한다.
        var payslip = await _payslipMapper.GetPayslip(payslipId);

        // 4. 급여명세서 급여내역 상세를 추가한다.
        foreach (var i in dto.PayslipSalaryDetailList!)
        {
            i.PayslipId = payslipId;
            i.CreaterId = dto.CreaterId;
        }
        await _payslipSalaryDetailMapper.AddPayslipSalaryDetail(dto.PayslipSalaryDetailList);

        // 5. 급여명세서 급여내역 상세 목록을 조회한다.
        payslip.PayslipSalaryDetailList = await _payslipSalaryDetailMapper.ListPayslipSalaryDetail(new GetPayslipRequestDTO
        {
            PayslipId = payslipId
        });

        // 6. 추가한 급여명세서를 반환한다.
        return payslip;
    }

    /// <summary>
    /// 급여명세서를 수정한다.
    /// </summary>
    [Transaction]
    public async Task<PayslipResultDTO> UpdatePayslip(SavePayslipRequestDTO dto)
    {
        // 1. 지급월에 해당하는 급여명세서가 있는지 조회힌다.
        var count = await _payslipMapper.CountPayslip(new GetPayslipRequestDTO
        {
            WorkHistoryId = dto.WorkHistoryId,
            PayslipId = dto.PayslipId,
            PayslipPaymentYmd = dto.PayslipPaymentYmd
        });

        if (count > 0)
        {
            var YYYYMM = Convert.ToDateTime(dto.PayslipPaymentYmd).ToString("yyyy년 MM월");
            throw new BizException($"{YYYYMM}에 이미 등록된 급여명세서가 있어요.");
        }

        // 2. 급여명세서를 수정한다.
        await _payslipMapper.UpdatePayslip(dto);

        // 3. 수정한 급여명세서를 조회한다.
        var payslip = await _payslipMapper.GetPayslip(dto.PayslipId);

        // 4. 급여명세서 급여내역 상세를 삭제한다.
        await _payslipSalaryDetailMapper.RemovePayslipSalaryDetail(dto.PayslipId);

        // 5. 급여명세서 급여내역 상세를 추가한다.
        foreach (var i in dto.PayslipSalaryDetailList!)
        {
            i.PayslipId = dto.PayslipId;
            i.CreaterId = dto.CreaterId;
        }
        await _payslipSalaryDetailMapper.AddPayslipSalaryDetail(dto.PayslipSalaryDetailList);

        // 6. 급여명세서 급여내역 상세 목록을 조회한다.
        payslip.PayslipSalaryDetailList = await _payslipSalaryDetailMapper.ListPayslipSalaryDetail(new GetPayslipRequestDTO
        {
            PayslipId = dto.PayslipId
        });

        // 7. 수정한 급여명세서를 반환한다.
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

