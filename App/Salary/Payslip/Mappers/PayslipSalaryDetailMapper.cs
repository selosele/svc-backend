using SmartSql;
using Svc.App.Salary.Payslip.Models.DTO;

namespace Svc.App.Salary.Payslip.Mappers;

/// <summary>
/// 급여명세서 급여내역 상세 매퍼 인터페이스
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
    {
        return SqlMapper.QueryAsync<PayslipSalaryDetailResultDTO>(new RequestContext
        {
            Scope = nameof(PayslipSalaryDetailMapper),
            SqlId = "ListPayslipSalaryDetail",
            Request = dto
        });
    }

    /// <summary>
    /// 급여명세서 급여내역 상세를 추가한다.
    /// </summary>
    public Task<int> AddPayslipSalaryDetail(List<AddPayslipSalaryDetailRequestDTO> dtoList)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(PayslipSalaryDetailMapper),
            SqlId = "AddPayslipSalaryDetail",
            Request = new { DTOList = dtoList }
        });
    }
    #endregion

}
