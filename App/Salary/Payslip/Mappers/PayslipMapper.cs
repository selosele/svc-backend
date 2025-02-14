using SmartSql;
using Svc.App.Shared.Extensions;
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
        => SqlMapper.QueryForObject<int>($"{nameof(PayslipMapper)}.CountPayslip", dto);

    /// <summary>
    /// 급여명세서 목록을 조회한다.
    /// </summary>
    public Task<IList<PayslipResultDTO>> ListPayslip(GetPayslipRequestDTO dto)
        => SqlMapper.QueryForList<PayslipResultDTO>($"{nameof(PayslipMapper)}.ListPayslip", dto);

    /// <summary>
    /// 이전/다음 급여명세서 목록을 조회한다.
    /// </summary>
    public Task<IList<PayslipResultDTO>> ListPrevNextPayslip(GetPayslipRequestDTO dto)
        => SqlMapper.QueryForList<PayslipResultDTO>($"{nameof(PayslipMapper)}.ListPrevNextPayslip", dto);

    /// <summary>
    /// 급여명세서를 조회한다.
    /// </summary>
    public Task<PayslipResultDTO> GetPayslip(GetPayslipRequestDTO dto)
        => SqlMapper.QueryForObject<PayslipResultDTO>($"{nameof(PayslipMapper)}.GetPayslip", dto);

    /// <summary>
    /// 급여명세서를 추가한다.
    /// </summary>
    public Task<int> AddPayslip(SavePayslipRequestDTO dto)
        => SqlMapper.ExecuteScalar<int>($"{nameof(PayslipMapper)}.AddPayslip", dto);

    /// <summary>
    /// 급여명세서를 수정한다.
    /// </summary>
    public Task<int> UpdatePayslip(SavePayslipRequestDTO dto)
        => SqlMapper.Execute($"{nameof(PayslipMapper)}.UpdatePayslip", dto);

    /// <summary>
    /// 급여명세서를 삭제한다.
    /// </summary>
    public Task<int> RemovePayslip(int? payslipId, int? updaterId)
        => SqlMapper.Execute($"{nameof(PayslipMapper)}.RemovePayslip", new { payslipId, updaterId });
    #endregion

}
