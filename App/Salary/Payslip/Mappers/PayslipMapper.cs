using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Salary.Payslip.Models.DTO;

namespace Svc.App.Salary.Payslip.Mappers;

/// <summary>
/// 급여명세서 매퍼
/// </summary>
public class PayslipMapper(ISqlMapper sqlMapper) : MyMapperBase(sqlMapper)
{
    #region [메서드]
    /// <summary>
    /// 급여명세서 개수를 조회한다.
    /// </summary>
    public Task<int> CountPayslip(GetPayslipRequestDTO dto)
        => QueryForObject<int>($"{nameof(PayslipMapper)}.CountPayslip", dto);

    /// <summary>
    /// 급여명세서 목록을 조회한다.
    /// </summary>
    public Task<IList<PayslipResultDTO>> ListPayslip(GetPayslipRequestDTO dto)
        => QueryForList<PayslipResultDTO>($"{nameof(PayslipMapper)}.ListPayslip", dto);

    /// <summary>
    /// 이전/다음 급여명세서 목록을 조회한다.
    /// </summary>
    public Task<IList<PayslipResultDTO>> ListPrevNextPayslip(GetPayslipRequestDTO dto)
        => QueryForList<PayslipResultDTO>($"{nameof(PayslipMapper)}.ListPrevNextPayslip", dto);

    /// <summary>
    /// 급여명세서를 조회한다.
    /// </summary>
    public Task<PayslipResultDTO> GetPayslip(GetPayslipRequestDTO dto)
        => QueryForObject<PayslipResultDTO>($"{nameof(PayslipMapper)}.GetPayslip", dto);

    /// <summary>
    /// 급여명세서를 추가한다.
    /// </summary>
    public Task<int> AddPayslip(SavePayslipRequestDTO dto)
        => ExecuteScalar<int>($"{nameof(PayslipMapper)}.AddPayslip", dto);

    /// <summary>
    /// 급여명세서를 수정한다.
    /// </summary>
    public Task<int> UpdatePayslip(SavePayslipRequestDTO dto)
        => Execute($"{nameof(PayslipMapper)}.UpdatePayslip", dto);

    /// <summary>
    /// 급여명세서를 삭제한다.
    /// </summary>
    public Task<int> RemovePayslip(int? payslipId, int? updaterId)
        => Execute($"{nameof(PayslipMapper)}.RemovePayslip", new { payslipId, updaterId });
    #endregion

}
