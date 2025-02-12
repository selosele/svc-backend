using SmartSql;
using Svc.App.Shared.Extensions;
using Svc.App.Human.Employee.Models.DTO;

namespace Svc.App.Human.Employee.Mappers;

/// <summary>
/// 근무이력 매퍼 클래스
/// </summary>
public class WorkHistoryMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public WorkHistoryMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 근무이력 목록을 조회한다.
    /// </summary>
    public Task<IList<WorkHistoryResultDTO>> ListWorkHistory(GetWorkHistoryRequestDTO dto)
        => SqlMapper.QueryForList<WorkHistoryResultDTO>($"{nameof(WorkHistoryMapper)}.ListWorkHistory", dto);

    /// <summary>
    /// 근무이력을 조회한다.
    /// </summary>
    public Task<WorkHistoryResultDTO> GetWorkHistory(GetWorkHistoryRequestDTO dto)
        => SqlMapper.QueryForObject<WorkHistoryResultDTO>($"{nameof(WorkHistoryMapper)}.GetWorkHistory", dto);

    /// <summary>
    /// 근무이력을 추가한다.
    /// </summary>
    public Task<int> AddWorkHistory(SaveWorkHistoryRequestDTO dto)
        => SqlMapper.ExecuteScalar<int>($"{nameof(WorkHistoryMapper)}.AddWorkHistory", dto);

    /// <summary>
    /// 근무이력을 수정한다.
    /// </summary>
    public Task<int> UpdateWorkHistory(SaveWorkHistoryRequestDTO dto)
        => SqlMapper.Execute($"{nameof(WorkHistoryMapper)}.UpdateWorkHistory", dto);

    /// <summary>
    /// 근무이력을 삭제한다.
    /// </summary>
    public Task<int> RemoveWorkHistory(int? userId, int workHistoryId)
        => SqlMapper.Execute($"{nameof(WorkHistoryMapper)}.RemoveWorkHistory", new { UpdaterId = userId, workHistoryId });
    #endregion

}
