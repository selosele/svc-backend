using SmartSql;
using Svc.App.Human.Vacation.Models.DTO;

namespace Svc.App.Human.Vacation.Mappers;

/// <summary>
/// 휴가 계산 설정 매퍼 인터페이스
/// </summary>
public class VacationCalcMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public VacationCalcMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 휴가 계산 설정 목록을 조회한다.
    /// </summary>
    public Task<IList<VacationCalcResultDTO>> ListVacationCalc(int? workHistoryId)
    {
        return SqlMapper.QueryAsync<VacationCalcResultDTO>(new RequestContext
        {
            Scope = nameof(VacationCalcMapper),
            SqlId = "ListVacationCalc",
            Request = new { workHistoryId }
        });
    }

    /// <summary>
    /// 휴가 계산 설정을 추가한다.
    /// </summary>
    public Task<int> AddVacationCalc(AddVacationCalcRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(VacationCalcMapper),
            SqlId = "AddVacationCalc",
            Request = new { DTO = dto }
        });
    }

    /// <summary>
    /// 휴가 계산 설정을 삭제한다.
    /// </summary>
    public Task<int> RemoveVacationCalc(int? workHistoryId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(VacationCalcMapper),
            SqlId = "RemoveVacationCalc",
            Request = new { workHistoryId }
        });
    }
    #endregion

}
