namespace Svc.App.Common.Menu.Models.DTO;

/// <summary>
/// 메뉴 권한 응답 DTO
/// </summary>
public record MenuRoleResponseDTO
{
    #region [필드]
    /// <summary>
    /// 메뉴 권한
    /// </summary>
    public MenuRoleResultDTO? MenuRole { get; set; }

    /// <summary>
    /// 메뉴 권한 목록
    /// </summary>
    public IList<MenuRoleResultDTO>? MenuRoleList { get; set; }
    #endregion

}
