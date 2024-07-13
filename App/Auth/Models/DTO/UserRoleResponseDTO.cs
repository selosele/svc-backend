namespace svc.App.Auth.Models.DTO;

/// <summary>
/// 사용자 권한 응답 DTO
/// </summary>
public record UserRoleResponseDTO
{
    #region Fields
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 권한 ID
    /// </summary>
    public string? RoleId { get; set; }

    /// <summary>
    /// 권한 명
    /// </summary>
    public string? RoleName { get; set; }
    #endregion

}
