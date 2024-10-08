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
    public Task<HolidayResponseDTO> GetHoliday(GetHolidayRequestDTO dto)
    {
        return SqlMapper.QuerySingleAsync<HolidayResponseDTO>(new RequestContext
        {
            Scope = nameof(HolidayRepository),
            SqlId = "GetHoliday",
            Request = dto
        });
    }

    /// <summary>
    /// 휴일을 추가한다.
    /// </summary>
    public Task<string> AddHoliday(SaveHolidayRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<string>(new RequestContext
        {
            Scope = nameof(HolidayRepository),
            SqlId = "AddHoliday",
            Request = dto
        });
    }

    /// <summary>
    /// 휴일을 수정한다.
    /// </summary>
    public Task<int> UpdateHoliday(SaveHolidayRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(HolidayRepository),
            SqlId = "UpdateHoliday",
            Request = dto
        });
    }

    /// <summary>
    /// 휴일을 삭제한다.
    /// </summary>
    public Task<int> RemoveHoliday(string ymd, int? userId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(HolidayRepository),
            SqlId = "RemoveHoliday",
            Request = new { ymd, userId }
        });
    }
    #endregion

}
