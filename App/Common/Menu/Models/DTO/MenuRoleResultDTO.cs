namespace Svc.App.Common.Menu.Models.DTO;

/// <summary>
/// 메뉴 권한 조회 결과 DTO
/// </summary>
public record MenuRoleResultDTO
{
    #region [필드]
    /// <summary>
    /// 메뉴 ID
    /// </summary>
    public int? MenuId { get; set; }

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
