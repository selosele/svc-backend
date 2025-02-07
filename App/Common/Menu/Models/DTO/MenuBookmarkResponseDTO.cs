namespace Svc.App.Common.Menu.Models.DTO;

/// <summary>
/// 메뉴 즐겨찾기 응답 DTO
/// </summary>
public record MenuBookmarkResponseDTO
{
    #region [필드]
    /// <summary>
    /// 메뉴 즐겨찾기
    /// </summary>
    public MenuBookmarkResultDTO? MenuBookmark { get; set; }

    /// <summary>
    /// 메뉴 즐겨찾기 목록
    /// </summary>
    public IList<MenuBookmarkResultDTO>? MenuBookmarkList { get; set; }
    #endregion

}
