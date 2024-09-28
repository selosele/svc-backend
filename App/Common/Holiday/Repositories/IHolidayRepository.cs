using Svc.App.Common.Holiday.Models.DTO;

namespace Svc.App.Common.Holiday.Repositories;

/// <summary>
/// 휴일 리포지토리 인터페이스
/// </summary>
public interface IHolidayRepository
{
    #region Methods
    /// <summary>
    /// 휴일 목록을 조회한다.
    /// </summary>
    Task<IList<HolidayResponseDTO>> ListHoliday(GetHolidayRequestDTO? dto);

    /// <summary>
    /// 휴일을 조회한다.
    /// </summary>
    Task<HolidayResponseDTO> GetHoliday(GetHolidayRequestDTO dto);

    /// <summary>
    /// 휴일을 수정한다.
    /// </summary>
    Task<int> UpdateHoliday(SaveHolidayRequestDTO dto);

    /// <summary>
    /// 휴일을 삭제한다.
    /// </summary>
    Task<int> RemoveHoliday(string ymd, int userId);
    #endregion

}
