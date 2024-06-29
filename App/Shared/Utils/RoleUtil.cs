namespace svc.App.Shared.Utils;

/// <summary>
/// 권한 유틸 클래스
/// </summary>
public class RoleUtil
{
    /// <summary>
    /// 권한 ID 접두사
    /// </summary>
    public const string prefix = "ROLE_";
    
    /// <summary>
    /// 시스템 관리자 권한
    /// </summary>
    public const string systemAdmin = $"{prefix}SYSTEM_ADMIN";

    /// <summary>
    /// 게시판 관리자 권한
    /// </summary>
    public const string boardAdmin = $"{prefix}BOARD_ADMIN";

    /// <summary>
    /// 직원 권한
    /// </summary>
    public const string employee = $"{prefix}EMPLOYEE";

}
