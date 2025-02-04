using SmartSql;
using Svc.App.Salary.Payslip.Models.DTO;

namespace Svc.App.Salary.Payslip.Mappers;

/// <summary>
/// 급여명세서 매퍼 인터페이스
/// </summary>
public class PayslipMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public PayslipMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 급여명세서 목록을 조회한다.
    /// </summary>
    public Task<IList<PayslipResponseDTO>> ListPayslip(GetPayslipRequestDTO dto)
    {
        return SqlMapper.QueryAsync<PayslipResponseDTO>(new RequestContext
        {
            Scope = nameof(PayslipMapper),
            SqlId = "ListPayslip",
            Request = dto
        });
    }
    #endregion

}
