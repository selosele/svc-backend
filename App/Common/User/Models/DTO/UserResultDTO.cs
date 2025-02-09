using Svc.App.Human.Employee.Models.DTO;

namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 조회 결과 DTO
/// </summary>
public record UserResultDTO
{
    #region [필드]
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 사용자 계정
    /// </summary>
    public string? UserAccount { get; set; }

    /// <summary>
    /// 직원명
    /// </summary>
    public string? EmployeeName { get; set; }

    /// <summary>
    /// 회사명
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// 직위 코드
    /// </summary>
    public string? RankCode { get; set; }

    /// <summary>
    /// 직위 코드명
    /// </summary>
    public string? RankCodeName { get; set; }

    /// <summary>
    /// 직책 코드
    /// </summary>
    public string? JobTitleCode { get; set; }

    /// <summary>
    /// 직책 코드명
    /// </summary>
    public string? JobTitleCodeName { get; set; }

    /// <summary>
    /// 사용자 활성화 여부
    /// </summary>
    public string? UserActiveYn { get; set; }

    /// <summary>
    /// 마지막 로그인 일시
    /// </summary>
    public string? LastLoginDt { get; set; }

    /// <summary>
    /// 사용자 권한 목록 (문자열)
    /// </summary>
    public string? RolesString { get; set; }

    /// <summary>
    /// 권한 ID
    /// </summary>
    public string? RoleId { get; set; }

    /// <summary>
    /// 메뉴 ID
    /// </summary>
    public int? MenuId { get; set; }

    /// <summary>
    /// 사용자 권한 목록
    /// </summary>
    public IList<UserRoleResultDTO>? Roles { get; set; } = [];

    /// <summary>
    /// 직원 정보
    /// </summary>
    public EmployeeResultDTO? Employee { get; set; }
    #endregion
    
}
