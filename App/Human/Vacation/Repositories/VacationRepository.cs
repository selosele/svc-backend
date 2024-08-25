using SmartSql;
using Svc.App.Human.Vacation.Models.DTO;

namespace Svc.App.Human.Vacation.Repositories;

/// <summary>
/// 휴가 리포지토리 인터페이스
/// </summary>
public class VacationRepository : IVacationRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public VacationRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 휴가 목록을 조회한다.
    /// </summary>
    public Task<IList<VacationResponseDTO>> ListVacation(GetVacationRequestDTO getVacationRequestDTO)
    {
        return SqlMapper.QueryAsync<VacationResponseDTO>(new RequestContext
        {
            Scope = nameof(VacationRepository),
            SqlId = "ListVacation",
            Request = getVacationRequestDTO
        });
    }

    /// <summary>
    /// 휴가를 조회한다.
    /// </summary>
    public Task<VacationResponseDTO> GetVacation(int vacationId)
    {
        return SqlMapper.QuerySingleAsync<VacationResponseDTO>(new RequestContext
        {
            Scope = nameof(VacationRepository),
            SqlId = "GetVacation",
            Request = new { vacationId }
        });
    }

    /// <summary>
    /// 휴가를 삭제한다.
    /// </summary>
    public Task<int> RemoveVacation(int vacationId, int updaterId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(VacationRepository),
            SqlId = "RemoveVacation",
            Request = new { vacationId, updaterId }
        });
    }
    #endregion

}
