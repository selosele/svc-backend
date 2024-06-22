using svc.App.Shared.Models.Entities;

namespace svc.App.Menu.Models.Entities;

/// <summary>
/// 메뉴 권한 Entity
/// </summary>
public record MenuRoleEntity : MyEntityBase
{
    /// <summary>
    /// 메뉴 ID
    /// </summary>
    public int? MenuId { get; set; }

    /// <summary>
    /// 권한 ID
    /// </summary>
    public string? RoleId { get; set; }

}
