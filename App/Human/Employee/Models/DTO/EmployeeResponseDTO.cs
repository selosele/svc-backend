namespace svc.App.Human.Employee.Models.DTO;

/// <summary>
/// 직원 응답 DTO
/// </summary>
public record EmployeeResponseDTO
{
    #region Fields
    /// <summary>
    /// 직원 ID
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// 직원 명
    /// </summary>
    public string? EmployeeName { get; set; }
    
    /// <summary>
    /// 성별 코드
    /// </summary>
    public string? GenderCode { get; set; }
    
    /// <summary>
    /// 성별 코드 명
    /// </summary>
    public string? GenderCodeName { get; set; }

    /// <summary>
    /// 직원 회사 정보
    /// </summary>
    public EmployeeCompanyResponseDTO? EmployeeCompany { get; set; } = null;
    #endregion

}
