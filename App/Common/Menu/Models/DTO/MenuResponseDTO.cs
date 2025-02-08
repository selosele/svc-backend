namespace Svc.App.Common.Menu.Models.DTO;

/// <summary>
/// 메뉴 응답 DTO
/// </summary>
public record MenuResponseDTO
{
    #region [필드]
    /// <summary>
    /// 메뉴
    /// </summary>
    public MenuResultDTO? Menu { get; set; }
    
    /// <summary>
    /// 메뉴 목록
    /// </summary>
    public IList<MenuResultDTO>? MenuList { get; set; }
    #endregion

}
