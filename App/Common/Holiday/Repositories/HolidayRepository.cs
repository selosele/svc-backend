using SmartSql;
using Svc.App.Common.Holiday.Models.DTO;

namespace Svc.App.Common.Holiday.Repositories;

/// <summary>
/// 휴일 리포지토리 클래스
/// </summary>
public class HolidayRepository : IHolidayRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public HolidayRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 휴일 목록을 조회한다.
    /// </summary>
    public Task<IList<HolidayResponseDTO>> ListHoliday(GetHolidayRequestDTO? dto)
    {
        return SqlMapper.QueryAsync<HolidayResponseDTO>(new RequestContext
        {
            Scope = nameof(HolidayRepository),
            SqlId = "ListHoliday",
            Request = dto
        });
    }

    /// <summary>
    /// 휴일을 조회한다.
    /// </summary>
    public Task<HolidayResponseDTO> GetHoliday(string ymd)
    {
        return SqlMapper.QuerySingleAsync<HolidayResponseDTO>(new RequestContext
        {
            Scope = nameof(HolidayRepository),
            SqlId = "GetHoliday",
            Request = new { ymd }
        });
    }
    #endregion

}
