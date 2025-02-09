namespace Svc.App.Human.Employee.Models.DTO;

/// <summary>
/// 직원 응답 DTO
/// </summary>
public record EmployeeResponseDTO
{
    #region [필드]
    /// <summary>
    /// 직원
    /// </summary>
    public EmployeeResultDTO? Employee { get; set; }

    /// <summary>
    /// 직원 목록
    /// </summary>
    public IList<EmployeeResultDTO>? EmployeeList { get; set; }
    #endregion

}
