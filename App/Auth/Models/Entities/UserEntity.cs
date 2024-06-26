using svc.App.Shared.Models.Entities;

namespace svc.App.Auth.Models.Entities;

/// <summary>
/// 사용자 Entity
/// </summary>
public record UserEntity : MyEntityBase
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
    /// 사용자 비밀번호
    /// </summary>
    public string? UserPassword { get; set; }

    /// <summary>
    /// 사용자 명
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// 사용자 활성화 여부
    /// </summary>
    public string? UserActiveYn { get; set; }

    /// <summary>
    /// 사용자 권한 목록
    /// </summary>
    public IList<UserRoleEntity> Roles { get; set; } = [];

}
