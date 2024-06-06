namespace svc.App.Auth.Models.Entities;

/// <summary>
/// 사용자 Entity
/// </summary>
public class UserEntity
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
