using SmartSql.AOP;
using Svc.App.Common.Holiday.Models.DTO;
using Svc.App.Common.Holiday.Mappers;

namespace Svc.App.Common.Holiday.Services;

/// <summary>
/// 휴일 서비스 클래스
/// </summary>
public class HolidayService
{
    #region Fields
    private readonly HolidayMapper _holidayMapper;
    #endregion
    
    #region Constructor
    public HolidayService(
        HolidayMapper holidayMapper
    ) {
        _holidayMapper = holidayMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 휴일 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<HolidayResponseDTO>> ListHoliday(GetHolidayRequestDTO? dto)
        => await _holidayMapper.ListHoliday(dto);

    /// <summary>
    /// 휴일을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<HolidayResponseDTO> GetHoliday(GetHolidayRequestDTO dto)
        => await _holidayMapper.GetHoliday(dto);

    /// <summary>
    /// 휴일을 추가한다.
    /// </summary>
    [Transaction]
    public async Task<HolidayResponseDTO> AddHoliday(SaveHolidayRequestDTO dto)
    {
        var holidayId = await _holidayMapper.AddHoliday(dto);
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
        => await _holidayMapper.UpdateHoliday(dto);

    /// <summary>
    /// 휴일을 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveHoliday(string ymd, int? userId)
        => await _holidayMapper.RemoveHoliday(ymd, userId);
    #endregion
    
}

