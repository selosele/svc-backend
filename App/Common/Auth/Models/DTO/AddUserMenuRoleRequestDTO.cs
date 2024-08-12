using svc.App.Shared.Models.DTO;

namespace svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 사용자 메뉴 권한 추가 요청 DTO
/// </summary>
public record AddUserMenuRoleRequestDTO : HttpRequestDTOBase
{
    #region Fields
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
    #endregion

}
