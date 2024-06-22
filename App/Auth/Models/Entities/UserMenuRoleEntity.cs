using svc.App.Shared.Models.Entities;

namespace svc.App.Auth.Models.Entities;

/// <summary>
/// 사용자 메뉴 권한 Entity
/// </summary>
public record UserMenuRoleEntity : MyEntityBase
{
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 메뉴 ID
    /// </summary>
    public int? MenuId { get; set; }

    /// <summary>
    /// 권한 ID
    /// </summary>
    public string? RoleId { get; set; }

}
