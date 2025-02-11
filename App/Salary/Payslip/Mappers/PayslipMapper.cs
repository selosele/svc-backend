using SmartSql;
using Svc.App.Salary.Payslip.Models.DTO;

namespace Svc.App.Salary.Payslip.Mappers;

/// <summary>
/// 급여명세서 매퍼 클래스
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
    /// 급여명세서 개수를 조회한다.
    /// </summary>
    public Task<int> CountPayslip(GetPayslipRequestDTO dto)
    {
        return SqlMapper.QuerySingleAsync<int>(new RequestContext
        {
            Scope = nameof(PayslipMapper),
            SqlId = "CountPayslip",
            Request = dto
        });
    }

    /// <summary>
    /// 급여명세서 목록을 조회한다.
    /// </summary>
    public Task<IList<PayslipResultDTO>> ListPayslip(GetPayslipRequestDTO dto)
    {
        return SqlMapper.QueryAsync<PayslipResultDTO>(new RequestContext
        {
            Scope = nameof(PayslipMapper),
            SqlId = "ListPayslip",
            Request = dto
        });
    }

    /// <summary>
    /// 이전/다음 급여명세서 목록을 조회한다.
    /// </summary>
    public Task<IList<PayslipResultDTO>> ListPrevNextPayslip(GetPayslipRequestDTO dto)
    {
        return SqlMapper.QueryAsync<PayslipResultDTO>(new RequestContext
        {
            Scope = nameof(PayslipMapper),
            SqlId = "ListPrevNextPayslip",
            Request = dto
        });
    }

    /// <summary>
    /// 급여명세서를 조회한다.
    /// </summary>
    public Task<PayslipResultDTO> GetPayslip(int payslipId)
    {
        return SqlMapper.QuerySingleAsync<PayslipResultDTO>(new RequestContext
        {
            Scope = nameof(PayslipMapper),
            SqlId = "GetPayslip",
            Request = new { payslipId }
        });
    }

    /// <summary>
    /// 급여명세서를 추가한다.
    /// </summary>
    public Task<int> AddPayslip(SavePayslipRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<int>(new RequestContext
        {
            Scope = nameof(PayslipMapper),
            SqlId = "AddPayslip",
            Request = dto
        });
    }

    /// <summary>
    /// 급여명세서를 삭제한다.
    /// </summary>
    public Task<int> RemovePayslip(int payslipId, int? updaterId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(PayslipMapper),
            SqlId = "RemovePayslip",
            Request = new { payslipId, updaterId }
        });
    }
    #endregion

}
