using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Salary.Payslip.Models.DTO;

namespace Svc.App.Salary.Payslip.Mappers;

/// <summary>
/// 급여명세서 급여내역 상세 매퍼
/// </summary>
public class PayslipSalaryDetailMapper(ISqlMapper sqlMapper) : MyMapperBase(sqlMapper)
{
    #region [메서드]
    /// <summary>
    /// 급여명세서 급여내역 상세 목록을 조회한다.
    /// </summary>
    public Task<IList<PayslipSalaryDetailResultDTO>> ListPayslipSalaryDetail(GetPayslipRequestDTO dto)
        => QueryForList<PayslipSalaryDetailResultDTO>($"{nameof(PayslipSalaryDetailMapper)}.ListPayslipSalaryDetail", dto);

    /// <summary>
    /// 급여명세서 급여내역 상세를 추가한다.
    /// </summary>
    public Task<int> AddPayslipSalaryDetail(List<AddPayslipSalaryDetailRequestDTO> dtoList)
        => Execute($"{nameof(PayslipSalaryDetailMapper)}.AddPayslipSalaryDetail", new { DTOList = dtoList });

    /// <summary>
    /// 급여명세서 급여내역 상세를 삭제한다.
    /// </summary>
    public Task<int> RemovePayslipSalaryDetail(int? payslipId)
        => Execute($"{nameof(PayslipSalaryDetailMapper)}.RemovePayslipSalaryDetail", new { payslipId });
    #endregion

}
