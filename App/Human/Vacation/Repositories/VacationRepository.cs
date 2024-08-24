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
    #endregion

}
