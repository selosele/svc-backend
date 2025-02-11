using SmartSql;
using Svc.App.Human.Vacation.Models.DTO;

namespace Svc.App.Human.Vacation.Mappers;

/// <summary>
/// 휴가 매퍼 클래스
/// </summary>
public class VacationMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public VacationMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 휴가 목록을 조회한다.
    /// </summary>
    public Task<IList<VacationResultDTO>> ListVacation(GetVacationRequestDTO dto)
    {
        return SqlMapper.QueryAsync<VacationResultDTO>(new RequestContext
        {
            Scope = nameof(VacationMapper),
            SqlId = "ListVacation",
            Request = dto
        });
    }

    /// <summary>
    /// 휴가를 조회한다.
    /// </summary>
    public Task<VacationResultDTO> GetVacation(int vacationId)
    {
        return SqlMapper.QuerySingleAsync<VacationResultDTO>(new RequestContext
        {
            Scope = nameof(VacationMapper),
            SqlId = "GetVacation",
            Request = new { vacationId }
        });
    }

    /// <summary>
    /// 휴가를 추가한다.
    /// </summary>
    public Task<int> AddVacation(SaveVacationRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<int>(new RequestContext
        {
            Scope = nameof(VacationMapper),
            SqlId = "AddVacation",
            Request = dto
        });
    }

    /// <summary>
    /// 휴가를 수정한다.
    /// </summary>
    public Task<int> UpdateVacation(SaveVacationRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(VacationMapper),
            SqlId = "UpdateVacation",
            Request = dto
        });
    }

    /// <summary>
    /// 휴가를 삭제한다.
    /// </summary>
    public Task<int> RemoveVacation(int vacationId, int? updaterId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(VacationMapper),
            SqlId = "RemoveVacation",
            Request = new { vacationId, updaterId }
        });
    }

    /// <summary>
    /// 휴가일수정보를 조회한다.
    /// </summary>
    public Task<VacationCountInfoResultDTO> GetVacationCountInfo(GetVacationCountInfoRequestDTO dto)
    {
        return SqlMapper.QuerySingleAsync<VacationCountInfoResultDTO>(new RequestContext
        {
            Scope = nameof(VacationMapper),
            SqlId = "GetVacationCountInfo",
            Request = dto
        });
    }

    /// <summary>
    /// 월별 휴가사용일수 목록을 조회한다.
    /// </summary>
    public Task<IList<VacationByMonthResultDTO>> ListVacationByMonth(GetVacationByMonthRequestDTO dto)
    {
        return SqlMapper.QueryAsync<VacationByMonthResultDTO>(new RequestContext
        {
            Scope = nameof(VacationMapper),
            SqlId = "ListVacationByMonth",
            Request = dto
        });
    }
    #endregion

}
