using SmartSql;
using Svc.App.Shared.Extensions;
using Svc.App.Salary.Payslip.Models.DTO;

namespace Svc.App.Salary.Payslip.Mappers;

/// <summary>
/// 급여명세서 급여내역 상세 매퍼 클래스
/// </summary>
public class PayslipSalaryDetailMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public PayslipSalaryDetailMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 급여명세서 급여내역 상세 목록을 조회한다.
    /// </summary>
    public Task<IList<PayslipSalaryDetailResultDTO>> ListPayslipSalaryDetail(GetPayslipRequestDTO dto)
        => SqlMapper.QueryForList<PayslipSalaryDetailResultDTO>($"{nameof(PayslipSalaryDetailMapper)}.ListPayslipSalaryDetail", dto);

    /// <summary>
    /// 급여명세서 급여내역 상세를 추가한다.
    /// </summary>
    public Task<int> AddPayslipSalaryDetail(List<AddPayslipSalaryDetailRequestDTO> dtoList)
        => SqlMapper.Execute($"{nameof(PayslipSalaryDetailMapper)}.AddPayslipSalaryDetail", new { DTOList = dtoList });

    /// <summary>
    /// 급여명세서 급여내역 상세를 삭제한다.
    /// </summary>
    public Task<int> RemovePayslipSalaryDetail(int payslipId)
        => SqlMapper.Execute($"{nameof(PayslipSalaryDetailMapper)}.RemovePayslipSalaryDetail", new { payslipId });
    #endregion

}
