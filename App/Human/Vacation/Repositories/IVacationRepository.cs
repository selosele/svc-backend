using Svc.App.Human.Vacation.Models.DTO;

namespace Svc.App.Human.Vacation.Repositories;

/// <summary>
/// 휴가 리포지토리 인터페이스
/// </summary>
public interface IVacationRepository
{
    #region Methods
    /// <summary>
    /// 휴가 목록을 조회한다.
    /// </summary>
    Task<IList<VacationResponseDTO>> ListVacation(GetVacationRequestDTO getVacationRequestDTO);

    /// <summary>
    /// 휴가를 조회한다.
    /// </summary>
    Task<VacationResponseDTO> GetVacation(int vacationId);

    /// <summary>
    /// 휴가를 삭제한다.
    /// </summary>
    Task<int> RemoveVacation(int vacationId, int updaterId);
    #endregion

}
