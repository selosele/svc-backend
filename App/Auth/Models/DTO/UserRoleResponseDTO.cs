namespace svc.App.Auth.Models.DTO;

/// <summary>
/// 사용자 권한 응답 DTO
/// </summary>
public class UserRoleResponseDTO
{
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 권한 ID
    /// </summary>
    public string? RoleId { get; set; }

}
