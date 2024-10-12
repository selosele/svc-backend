using SmartSql;
using Svc.App.Human.Employee.Models.DTO;

namespace Svc.App.Human.Employee.Mappers;

/// <summary>
/// 근무이력 매퍼 클래스
/// </summary>
public class WorkHistoryMapper : IWorkHistoryMapper
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public WorkHistoryMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 근무이력 목록을 조회한다.
    /// </summary>
    public Task<IList<WorkHistoryResponseDTO>> ListWorkHistory(GetWorkHistoryRequestDTO dto)
    {
        return SqlMapper.QueryAsync<WorkHistoryResponseDTO>(new RequestContext
        {
            Scope = nameof(WorkHistoryMapper),
            SqlId = "ListWorkHistory",
            Request = dto
        });
    }

    /// <summary>
    /// 근무이력을 조회한다.
    /// </summary>
    public Task<WorkHistoryResponseDTO> GetWorkHistory(GetWorkHistoryRequestDTO dto)
    {
        return SqlMapper.QuerySingleAsync<WorkHistoryResponseDTO>(new RequestContext
        {
            Scope = nameof(WorkHistoryMapper),
            SqlId = "GetWorkHistory",
            Request = dto
        });
    }

    /// <summary>
    /// 근무이력을 추가한다.
    /// </summary>
    public Task<int> AddWorkHistory(SaveWorkHistoryRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<int>(new RequestContext
        {
            Scope = nameof(WorkHistoryMapper),
            SqlId = "AddWorkHistory",
            Request = dto
        });
    }

    /// <summary>
    /// 근무이력을 수정한다.
    /// </summary>
    public Task<int> UpdateWorkHistory(SaveWorkHistoryRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(WorkHistoryMapper),
            SqlId = "UpdateWorkHistory",
            Request = dto
        });
    }

    /// <summary>
    /// 근무이력을 삭제한다.
    /// </summary>
    public Task<int> RemoveWorkHistory(int? userId, int workHistoryId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(WorkHistoryMapper),
            SqlId = "RemoveWorkHistory",
            Request = new { UpdaterId = userId, workHistoryId }
        });
    }
    #endregion

}
