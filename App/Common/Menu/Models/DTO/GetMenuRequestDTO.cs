using svc.App.Shared.Models.DTO;

namespace svc.App.Common.Menu.Models.DTO;

/// <summary>
/// 메뉴 조회 요청 DTO
/// </summary>
public record GetMenuRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 메뉴 ID
    /// </summary>
    public int? MenuId { get; set; }

    /// <summary>
    /// 상위 메뉴 ID
    /// </summary>
    public int? UpMenuId { get; set; }

    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 권한 ID 목록
    /// </summary>
    public List<string>? RoleIdList { get; set; }
    #endregion

}
