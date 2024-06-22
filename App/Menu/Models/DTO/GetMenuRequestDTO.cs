using svc.App.Shared.Models.DTO;

namespace svc.App.Menu.Models.DTO;

/// <summary>
/// 메뉴 조회 요청 DTO
/// </summary>
public record GetMenuRequestDTO : MyRequestDTOBase
{
    /// <summary>
    /// 메뉴 ID
    /// </summary>
    public int? MenuId { get; set; }

    /// <summary>
    /// 상위 메뉴 ID
    /// </summary>
    public int? UpMenuId { get; set; }

    /// <summary>
    /// 메뉴 표출여부
    /// </summary>
    public string? MenuShowYn { get; set; }

    /// <summary>
    /// 메뉴 사용여부
    /// </summary>
    public string? MenuUseYn { get; set; }

    /// <summary>
    /// 메뉴 삭제여부
    /// </summary>
    public string? MenuDeleteYn { get; set; }

}
