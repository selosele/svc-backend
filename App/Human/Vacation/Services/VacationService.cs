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
    public async Task<IList<VacationResponseDTO>> ListVacation(GetVacationRequestDTO dto)
        => await _vacationRepository.ListVacation(dto);

    /// <summary>
    /// 휴가를 조회한다.
    /// </summary>
    [Transaction]
    public async Task<VacationResponseDTO> GetVacation(int vacationId)
        => await _vacationRepository.GetVacation(vacationId);

    /// <summary>
    /// 휴가를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<VacationResponseDTO> AddVacation(SaveVacationRequestDTO dto)
    {
        var vacationId = await _vacationRepository.AddVacation(dto);
        return await _vacationRepository.GetVacation(vacationId);
    }

    /// <summary>
    /// 휴가를 수정한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateVacation(SaveVacationRequestDTO dto)
        => await _vacationRepository.UpdateVacation(dto);

    /// <summary>
    /// 휴가를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveVacation(int vacationId, int updaterId)
        => await _vacationRepository.RemoveVacation(vacationId, updaterId);
    #endregion
    
}

