using Svc.App.Human.Vacation.Models.DTO;

namespace Svc.App.Human.Vacation.Mappers;

/// <summary>
/// 휴가 매퍼 인터페이스
/// </summary>
public interface IVacationMapper
{
    #region Methods
    /// <summary>
    /// 휴가 목록을 조회한다.
    /// </summary>
    Task<IList<VacationResponseDTO>> ListVacation(GetVacationRequestDTO dto);

    /// <summary>
    /// 휴가를 조회한다.
    /// </summary>
    Task<VacationResponseDTO> GetVacation(int vacationId);

    /// <summary>
    /// 휴가를 추가한다.
    /// </summary>
    Task<int> AddVacation(SaveVacationRequestDTO dto);

    /// <summary>
    /// 휴가를 수정한다.
    /// </summary>
    Task<int> UpdateVacation(SaveVacationRequestDTO dto);

    /// <summary>
    /// 휴가를 삭제한다.
    /// </summary>
    Task<int> RemoveVacation(int vacationId, int? updaterId);
    #endregion

}
