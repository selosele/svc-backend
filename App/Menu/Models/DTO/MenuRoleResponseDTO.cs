namespace svc.App.Menu.Models.DTO;

/// <summary>
/// 메뉴 권한 응답 DTO
/// </summary>
public class MenuRoleResponseDTO
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
