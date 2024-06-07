using svc.App.Shared.Models.Entities;

namespace svc.App.Auth.Models.Entities;

/// <summary>
/// 권한 Entity
/// </summary>
public class RoleEntity : MyEntityBase
{
    /// <summary>
    /// 권한 ID
    /// </summary>
    public string? RoleId { get; set; }

    /// <summary>
    /// 권한 명
    /// </summary>
    public string? RoleName { get; set; }

}
