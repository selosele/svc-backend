namespace Svc.App.Human.Employee.Models.DTO;

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
    /// 회사 ID
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// 직원명
    /// </summary>
    public string? EmployeeName { get; set; }
    
    /// <summary>
    /// 성별 코드
    /// </summary>
    public string? GenderCode { get; set; }
    
    /// <summary>
    /// 생년월일
    /// </summary>
    public string? BirthYmd { get; set; }
    
    /// <summary>
    /// 휴대폰번호
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// 직원 회사 정보
    /// </summary>
    public IList<EmployeeCompanyResponseDTO>? EmployeeCompanies { get; set; } = [];
    #endregion

}
