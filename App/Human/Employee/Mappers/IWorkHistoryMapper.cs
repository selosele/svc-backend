using Svc.App.Human.Employee.Models.DTO;

namespace Svc.App.Human.Employee.Mappers;

/// <summary>
/// 근무이력 매퍼 인터페이스
/// </summary>
public interface IWorkHistoryMapper
{
    #region Methods
    /// <summary>
    /// 근무이력 목록을 조회한다.
    /// </summary>
    Task<IList<WorkHistoryResponseDTO>> ListWorkHistory(GetWorkHistoryRequestDTO dto);

    /// <summary>
    /// 근무이력을 조회한다.
    /// </summary>
    Task<WorkHistoryResponseDTO> GetWorkHistory(GetWorkHistoryRequestDTO dto);

    /// <summary>
    /// 근무이력을 추가한다.
    /// </summary>
    Task<int> AddWorkHistory(SaveWorkHistoryRequestDTO dto);
    
    /// <summary>
    /// 근무이력을 수정한다.
    /// </summary>
    Task<int> UpdateWorkHistory(SaveWorkHistoryRequestDTO dto);

    /// <summary>
    /// 근무이력을 삭제한다.
    /// </summary>
    Task<int> RemoveWorkHistory(int? userId, int workHistoryId);
    #endregion

}
