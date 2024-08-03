using svc.App.Human.Employee.Models.DTO;

namespace svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 사용자 응답 DTO
/// </summary>
public record UserResponseDTO
{
    #region Fields
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 사용자 계정
    /// </summary>
    public string? UserAccount { get; set; }

    /// <summary>
    /// 직원 명
    /// </summary>
    public string? EmployeeName { get; set; }

    /// <summary>
    /// 회사 명
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// 사용자 활성화 여부
    /// </summary>
    public string? UserActiveYn { get; set; }

    /// <summary>
    /// 사용자 권한 목록 (문자열)
    /// </summary>
    public string? RolesString { get; set; }

    /// <summary>
    /// 사용자 권한 목록
    /// </summary>
    public IList<UserRoleResponseDTO>? Roles { get; set; } = [];

    /// <summary>
    /// 직원 정보
    /// </summary>
    public EmployeeResponseDTO? Employee { get; set; } = null;
    #endregion
    
}
