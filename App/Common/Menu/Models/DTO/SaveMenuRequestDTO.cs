using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Menu.Models.DTO;

/// <summary>
/// 메뉴 추가/수정 요청 DTO
/// </summary>
public record SaveMenuRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 기존 메뉴 ID
    /// </summary>
    public int? OriginalMenuId { get; set; }

    /// <summary>
    /// 메뉴 ID
    /// </summary>
    public int? MenuId { get; set; }

    /// <summary>
    /// 상위 메뉴 ID
    /// </summary>
    public int? UpMenuId { get; set; }

    /// <summary>
    /// 메뉴명
    /// </summary>
    public string? MenuName { get; set; }

    /// <summary>
    /// 메뉴 URL
    /// </summary>
    public string? MenuUrl { get; set; }

    /// <summary>
    /// 메뉴 순서
    /// </summary>
    public int? MenuOrder { get; set; }

    /// <summary>
    /// 메뉴 뎁스
    /// </summary>
    public int? MenuDepth { get; set; }

    /// <summary>
    /// 메뉴 표출 여부
    /// </summary>
    public string? MenuShowYn { get; set; }

    /// <summary>
    /// 메뉴 권한 목록
    /// </summary>
    public IList<string>? MenuRoleList { get; set; }
    #endregion

}
