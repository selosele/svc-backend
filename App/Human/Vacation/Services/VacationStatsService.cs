using SmartSql.AOP;
using Svc.App.Human.Vacation.Mappers;
using Svc.App.Human.Vacation.Models.DTO;

namespace Svc.App.Human.Vacation.Services;

/// <summary>
/// 휴가 서비스 클래스
/// </summary>
public class VacationStatsService
{
    #region [필드]
    private readonly VacationStatsMapper _vacationStatsMapper;
    #endregion
    
    #region [생성자]
    public VacationStatsService(
        VacationStatsMapper vacationStatsMapper
    )
    {
        _vacationStatsMapper = vacationStatsMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 휴가 통계 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<VacationStatsResponseDTO>> ListVacationStats(GetVacationStatsRequestDTO dto)
        => await _vacationStatsMapper.ListVacationStats(dto);

    /// <summary>
    /// 휴가 통계를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<int> AddVacationStats(AddVacationStatsRequestDTO dto)
    {
        // 모든 휴가 통계를 삭제하고
        await _vacationStatsMapper.RemoveVacationStats(dto.UserId);

        // 다시 추가한다.
        return await _vacationStatsMapper.AddVacationStats(dto);
    }
    #endregion
    
}

