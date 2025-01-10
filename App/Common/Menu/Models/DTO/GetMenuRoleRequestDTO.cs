using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Menu.Models.DTO;

/// <summary>
/// 메뉴 권한 조회 요청 DTO
/// </summary>
public record GetMenuRoleRequestDTO : HttpRequestDTOBase
{
    #region [필드]
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
