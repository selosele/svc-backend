using SmartSql.AOP;
using Svc.App.Common.Holiday.Models.DTO;
using Svc.App.Common.Holiday.Mappers;
using Svc.App.Human.Vacation.Mappers;
using Svc.App.Human.Vacation.Models.DTO;

namespace Svc.App.Common.Holiday.Services;

/// <summary>
/// 휴일 서비스 클래스
/// </summary>
public class HolidayService
{
    #region [필드]
    private readonly HolidayMapper _holidayMapper;
    private readonly VacationStatsMapper _vacationStatsMapper;
    #endregion
    
    #region [생성자]
    public HolidayService(
        HolidayMapper holidayMapper,
        VacationStatsMapper vacationStatsMapper
    ) {
        _holidayMapper = holidayMapper;
        _vacationStatsMapper = vacationStatsMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 휴일 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<HolidayResultDTO>> ListHoliday(GetHolidayRequestDTO? dto)
        => await _holidayMapper.ListHoliday(dto);

    /// <summary>
    /// 휴일을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<HolidayResultDTO> GetHoliday(GetHolidayRequestDTO dto)
        => await _holidayMapper.GetHoliday(dto);

    /// <summary>
    /// 휴일을 추가한다.
    /// </summary>
    [Transaction]
    public async Task<HolidayResultDTO> AddHoliday(SaveHolidayRequestDTO dto)
    {
        // 1. 휴일을 추가한다.
        var holidayId = await _holidayMapper.AddHoliday(dto);

        // 2. 모든 휴가 통계를 삭제하고
        await _vacationStatsMapper.RemoveVacationStats(dto.CreaterId);

        // 3. 휴가 통계를 추가한다.
        await _vacationStatsMapper.AddVacationStats(new AddVacationStatsRequestDTO { UserId = dto.CreaterId });

        // 4. 추가한 휴일을 조회해서 반환한다.
        return await _holidayMapper.GetHoliday(new GetHolidayRequestDTO
        {
            YMD = holidayId.Split("-")[0],
            UserId = int.Parse(holidayId.Split("-")[1])
        });
    }

    /// <summary>
    /// 휴일을 수정한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateHoliday(SaveHolidayRequestDTO dto)
    {
        // 1. 휴일을 수정한다.
        var updateHoliday = await _holidayMapper.UpdateHoliday(dto);

        // 2. 모든 휴가 통계를 삭제하고
        await _vacationStatsMapper.RemoveVacationStats(dto.UpdaterId);

        // 3. 휴가 통계를 추가한다.
        await _vacationStatsMapper.AddVacationStats(new AddVacationStatsRequestDTO { UserId = dto.UpdaterId });

        return updateHoliday;
    }

    /// <summary>
    /// 휴일을 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveHoliday(string ymd, int? userId)
    {
        // 1. 휴일을 삭제한다.
        var removeHoliday = await _holidayMapper.RemoveHoliday(ymd, userId);

        // 2. 모든 휴가 통계를 삭제하고
        await _vacationStatsMapper.RemoveVacationStats(userId);

        // 3. 휴가 통계를 추가한다.
        await _vacationStatsMapper.AddVacationStats(new AddVacationStatsRequestDTO { UserId = userId });

        return removeHoliday;
    }
    #endregion
    
}

