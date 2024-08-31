using SmartSql;
using Svc.App.Human.Employee.Models.DTO;

namespace Svc.App.Human.Employee.Repositories;

/// <summary>
/// 근무이력 리포지토리 클래스
/// </summary>
public class WorkHistoryRepository : IWorkHistoryRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public WorkHistoryRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 근무이력 목록을 조회한다.
    /// </summary>
    public Task<IList<WorkHistoryResponseDTO>> ListWorkHistory(int? employeeId)
    {
        return SqlMapper.QueryAsync<WorkHistoryResponseDTO>(new RequestContext
        {
            Scope = nameof(WorkHistoryRepository),
            SqlId = "ListWorkHistory",
            Request = new { employeeId }
        });
    }

    /// <summary>
    /// 근무이력을 조회한다.
    /// </summary>
    public Task<WorkHistoryResponseDTO> GetWorkHistory(GetWorkHistoryRequestDTO getWorkHistoryRequestDTO)
    {
        return SqlMapper.QuerySingleAsync<WorkHistoryResponseDTO>(new RequestContext
        {
            Scope = nameof(WorkHistoryRepository),
            SqlId = "GetWorkHistory",
            Request = getWorkHistoryRequestDTO
        });
    }

    /// <summary>
    /// 근무이력을 추가한다.
    /// </summary>
    public Task<int> AddWorkHistory(SaveWorkHistoryRequestDTO saveWorkHistoryRequestDTO)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(WorkHistoryRepository),
            SqlId = "AddWorkHistory",
            Request = saveWorkHistoryRequestDTO
        });
    }

    /// <summary>
    /// 근무이력을 수정한다.
    /// </summary>
    public Task<int> UpdateWorkHistory(SaveWorkHistoryRequestDTO saveWorkHistoryRequestDTO)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(WorkHistoryRepository),
            SqlId = "UpdateWorkHistory",
            Request = saveWorkHistoryRequestDTO
        });
    }

    /// <summary>
    /// 근무이력을 삭제한다.
    /// </summary>
    public Task<int> RemoveWorkHistory(int userId, int workHistoryId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(WorkHistoryRepository),
            SqlId = "RemoveWorkHistory",
            Request = new { UpdaterId = userId, workHistoryId }
        });
    }
    #endregion

}
