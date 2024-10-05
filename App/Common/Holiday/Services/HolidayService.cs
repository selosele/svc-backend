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
    public async Task<HolidayResponseDTO> GetHoliday(GetHolidayRequestDTO dto)
        => await _holidayRepository.GetHoliday(dto);

    /// <summary>
    /// 휴일을 추가한다.
    /// </summary>
    [Transaction]
    public async Task<string> AddHoliday(SaveHolidayRequestDTO dto)
        => await _holidayRepository.AddHoliday(dto);

    /// <summary>
    /// 휴일을 수정한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateHoliday(SaveHolidayRequestDTO dto)
        => await _holidayRepository.UpdateHoliday(dto);

    /// <summary>
    /// 휴일을 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveHoliday(string ymd, int userId)
        => await _holidayRepository.RemoveHoliday(ymd, userId);
    #endregion
    
}

