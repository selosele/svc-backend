namespace svc.App.Auth.Models.Entities;

/// <summary>
/// 권한 Entity
/// </summary>
public class RoleEntity
{
    /// <summary>
    /// 권한 ID
    /// </summary>
    public string? RoleId { get; set; }

    /// <summary>
    /// 권한 명
    /// </summary>
    public string? RoleName { get; set; }
    
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
