using Svc.App.Common.User.Models.DTO;
using Svc.App.Human.Employee.Models.DTO;

namespace Svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 로그인 결과 DTO
/// </summary>
public record LoginResultDTO
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
    /// 사용자 비밀번호
    /// </summary>
    public string? UserPassword { get; set; }

    /// <summary>
    /// 사용자 활성화 여부
    /// </summary>
    public string? UserActiveYn { get; set; }

    /// <summary>
    /// 임시 비밀번호 발급 여부
    /// </summary>
    public string? TempPasswordYn { get; set; }

    /// <summary>
    /// 임시 비밀번호 발급 일시
    /// </summary>
    public string? TempPasswordDt { get; set; }

    /// <summary>
    /// 마지막 로그인 일시
    /// </summary>
    public string? LastLoginDt { get; set; }

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
