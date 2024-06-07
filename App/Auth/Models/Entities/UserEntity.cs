using svc.App.Shared.Models.Entities;

namespace svc.App.Auth.Models.Entities;

/// <summary>
/// 사용자 Entity
/// </summary>
public class UserEntity : MyEntityBase
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

}
