namespace svc.App.Auth.Models.Entities;

/// <summary>
/// 사용자 권한 Entity
/// </summary>
public class UserRoleEntity
{
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 권한 ID
    /// </summary>
    public string? RoleId { get; set; }
    
    /// <summary>
    /// 등록자 ID
    /// </summary>
    public int? CreaterId { get; set; }
    
    /// <summary>
    /// 등록일시
    /// </summary>
    public DateTime? CreateDt { get; set; }
    
    /// <summary>
    /// 수정자 ID
    /// </summary>
    public int? UpdaterId { get; set; }

    /// <summary>
    /// 수정일시
    /// </summary>
    public DateTime? UpdateDt { get; set; }

}
