namespace svc.App.Auth.Models.DTO;

/// <summary>
/// 사용자 DTO
/// </summary>
public class UserResponseDTO
{
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 사용자 계정
    /// </summary>
    public string? UserAccount { get; set; }

    /// <summary>
    /// 사용자 권한 목록
    /// </summary>
    public List<UserRoleResponseDTO>? Roles { get; set; } = [];
    
}
