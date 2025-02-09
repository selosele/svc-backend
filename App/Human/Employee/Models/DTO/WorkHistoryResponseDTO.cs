namespace Svc.App.Human.Employee.Models.DTO;

/// <summary>
/// 근무이력 응답 DTO
/// </summary>
public record WorkHistoryResponseDTO
{
    #region [필드]
    /// <summary>
    /// 근무이력
    /// </summary>
    public WorkHistoryResultDTO? WorkHistory { get; set; }

    /// <summary>
    /// 근무이력 목록
    /// </summary>
    public IList<WorkHistoryResultDTO>? WorkHistoryList { get; set; }
    #endregion

}
