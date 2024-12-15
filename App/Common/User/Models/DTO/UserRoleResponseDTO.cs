namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 권한 응답 DTO
/// </summary>
public record UserRoleResponseDTO
{
    #region [필드]
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 권한 ID
    /// </summary>
    public string? RoleId { get; set; }

    /// <summary>
    /// 권한명
    /// </summary>
    public string? RoleName { get; set; }
    #endregion

}
