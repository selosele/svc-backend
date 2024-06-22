using svc.App.Shared.Models.Entities;

namespace svc.App.Auth.Models.Entities;

/// <summary>
/// 사용자 권한 Entity
/// </summary>
public record UserRoleEntity : MyEntityBase
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
