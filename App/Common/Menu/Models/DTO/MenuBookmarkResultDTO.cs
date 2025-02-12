namespace Svc.App.Common.Menu.Models.DTO;

/// <summary>
/// 메뉴 즐겨찾기 조회 결과 DTO
/// </summary>
public record MenuBookmarkResultDTO
{
    #region [필드]
    /// <summary>
    /// 메뉴 즐겨찾기 ID
    /// </summary>
    public int? MenuBookmarkId { get; set; }

    /// <summary>
    /// 메뉴 ID
    /// </summary>
    public int? MenuId { get; set; }

    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 메뉴명
    /// </summary>
    public string? MenuName { get; set; }

    /// <summary>
    /// 메뉴 URL
    /// </summary>
    public string? MenuUrl { get; set; }
    #endregion

}
