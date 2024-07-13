namespace svc.App.Employee.Models.DTO;

/// <summary>
/// 직원 조회 요청 DTO
/// </summary>
public record GetEmployeeRequestDTO
{
    #region Fields
    /// <summary>
    /// 직원 ID
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }
    #endregion

}
