using SmartSql.AOP;
using Svc.App.Human.Vacation.Repositories;
using Svc.App.Human.Vacation.Models.DTO;

namespace Svc.App.Human.Vacation.Services;

/// <summary>
/// 휴가 서비스 클래스
/// </summary>
public class VacationService
{
    #region Fields
    private readonly IVacationRepository _vacationRepository;
    #endregion
    
    #region Constructor
    public VacationService(IVacationRepository vacationRepository)
    {
        _vacationRepository = vacationRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 휴가 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<VacationResponseDTO>> ListVacation(GetVacationRequestDTO getVacationRequestDTO)
        => await _vacationRepository.ListVacation(getVacationRequestDTO);
    #endregion
    
}

