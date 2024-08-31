using Svc.App.Human.Employee.Models.DTO;

namespace Svc.App.Human.Employee.Repositories;

/// <summary>
/// 근무이력 리포지토리 인터페이스
/// </summary>
public interface IWorkHistoryRepository
{
    #region Methods
    /// <summary>
    /// 근무이력 목록을 조회한다.
    /// </summary>
    Task<IList<WorkHistoryResponseDTO>> ListWorkHistory(int? employeeId);

    /// <summary>
    /// 근무이력을 조회한다.
    /// </summary>
    Task<WorkHistoryResponseDTO> GetWorkHistory(GetWorkHistoryRequestDTO getWorkHistoryRequestDTO);

    /// <summary>
    /// 근무이력을 추가한다.
    /// </summary>
    Task<int> AddWorkHistory(SaveWorkHistoryRequestDTO saveWorkHistoryRequestDTO);
    
    /// <summary>
    /// 근무이력을 수정한다.
    /// </summary>
    Task<int> UpdateWorkHistory(SaveWorkHistoryRequestDTO saveWorkHistoryRequestDTO);

    /// <summary>
    /// 근무이력을 삭제한다.
    /// </summary>
    Task<int> RemoveWorkHistory(int userId, int workHistoryId);
    #endregion

}
