using SmartSql.AOP;
using Svc.App.Common.Holiday.Models.DTO;
using Svc.App.Common.Holiday.Repositories;

namespace Svc.App.Common.Holiday.Services;

/// <summary>
/// 휴일 서비스 클래스
/// </summary>
public class HolidayService
{
    #region Fields
    private readonly IHolidayRepository _holidayRepository;
    #endregion
    
    #region Constructor
    public HolidayService(
        IHolidayRepository holidayRepository
    ) {
        _holidayRepository = holidayRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 휴일 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<HolidayResponseDTO>> ListHoliday(GetHolidayRequestDTO? dto)
        => await _holidayRepository.ListHoliday(dto);

    /// <summary>
    /// 휴일을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<HolidayResponseDTO> GetHoliday(string ymd)
        => await _holidayRepository.GetHoliday(ymd);
    #endregion
    
}

