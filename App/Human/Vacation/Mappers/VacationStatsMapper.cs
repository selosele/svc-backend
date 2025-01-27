using SmartSql;
using Svc.App.Human.Vacation.Models.DTO;

namespace Svc.App.Human.Vacation.Mappers;

/// <summary>
/// 휴가 통계 매퍼 인터페이스
/// </summary>
public class VacationStatsMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public VacationStatsMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 휴가 통계 목록을 조회한다.
    /// </summary>
    public Task<IList<VacationStatsResultDTO>> ListVacationStats(GetVacationStatsRequestDTO dto)
    {
        return SqlMapper.QueryAsync<VacationStatsResultDTO>(new RequestContext
        {
            Scope = nameof(VacationStatsMapper),
            SqlId = "ListVacationStats",
            Request = dto
        });
    }

    /// <summary>
    /// 휴가 통계를 추가한다.
    /// </summary>
    public Task<int> AddVacationStats(AddVacationStatsRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<int>(new RequestContext
        {
            Scope = nameof(VacationStatsMapper),
            SqlId = "AddVacationStats",
            Request = dto
        });
    }

    /// <summary>
    /// 휴가 통계를 삭제한다.
    /// </summary>
    public Task<int> RemoveVacationStats(int? userId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(VacationStatsMapper),
            SqlId = "RemoveVacationStats",
            Request = new { userId }
        });
    }
    #endregion

}
