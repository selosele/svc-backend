using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Human.Vacation.Models.DTO;

namespace Svc.App.Human.Vacation.Mappers;

/// <summary>
/// 휴가 통계 매퍼 클래스
/// </summary>
public class VacationStatsMapper : MyMapperBase
{
    #region [생성자]
    public VacationStatsMapper(ISqlMapper sqlMapper) : base(sqlMapper) {}
    #endregion

    #region [메서드]
    /// <summary>
    /// 휴가 통계 목록을 조회한다.
    /// </summary>
    public Task<IList<VacationStatsResultDTO>> ListVacationStats(GetVacationStatsRequestDTO dto)
        => QueryForList<VacationStatsResultDTO>($"{nameof(VacationStatsMapper)}.ListVacationStats", dto);

    /// <summary>
    /// 휴가 통계를 추가한다.
    /// </summary>
    public Task<int> AddVacationStats(AddVacationStatsRequestDTO dto)
        => ExecuteScalar<int>($"{nameof(VacationStatsMapper)}.AddVacationStats", dto);

    /// <summary>
    /// 휴가 통계를 삭제한다.
    /// </summary>
    public Task<int> RemoveVacationStats(int? userId)
        => Execute($"{nameof(VacationStatsMapper)}.RemoveVacationStats", new { userId });
    #endregion

}
