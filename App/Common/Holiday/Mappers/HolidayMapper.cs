using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Common.Holiday.Models.DTO;

namespace Svc.App.Common.Holiday.Mappers;

/// <summary>
/// 휴일 매퍼 클래스
/// </summary>
public class HolidayMapper : MyMapperBase
{
    #region [생성자]
    public HolidayMapper(ISqlMapper sqlMapper) : base(sqlMapper) {}
    #endregion

    #region [메서드]
    /// <summary>
    /// 휴일 목록을 조회한다.
    /// </summary>
    public Task<IList<HolidayResultDTO>> ListHoliday(GetHolidayRequestDTO? dto)
        => QueryForList<HolidayResultDTO>($"{nameof(HolidayMapper)}.ListHoliday", dto);

    /// <summary>
    /// 휴일을 조회한다.
    /// </summary>
    public Task<HolidayResultDTO> GetHoliday(GetHolidayRequestDTO dto)
        => QueryForObject<HolidayResultDTO>($"{nameof(HolidayMapper)}.GetHoliday", dto);

    /// <summary>
    /// 휴일을 추가한다.
    /// </summary>
    public Task<string> AddHoliday(SaveHolidayRequestDTO dto)
        => ExecuteScalar<string>($"{nameof(HolidayMapper)}.AddHoliday", dto);

    /// <summary>
    /// 휴일을 수정한다.
    /// </summary>
    public Task<int> UpdateHoliday(SaveHolidayRequestDTO dto)
        => Execute($"{nameof(HolidayMapper)}.UpdateHoliday", dto);

    /// <summary>
    /// 휴일을 삭제한다.
    /// </summary>
    public Task<int> RemoveHoliday(string ymd, int? userId)
        => Execute($"{nameof(HolidayMapper)}.RemoveHoliday", new { ymd, userId });
    #endregion

}
