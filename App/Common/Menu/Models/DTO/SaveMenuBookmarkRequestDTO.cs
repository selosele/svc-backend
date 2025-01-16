using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Menu.Models.DTO;

/// <summary>
/// 메뉴 즐겨찾기 추가/수정 요청 DTO
/// </summary>
public record SaveMenuBookmarkRequestDTO : HttpRequestDTOBase
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
    #endregion

}
