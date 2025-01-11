using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Menu.Models.DTO;

/// <summary>
/// 메뉴 권한 추가 요청 DTO
/// </summary>
public record AddMenuRoleRequestDTO : HttpRequestDTOBase
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
    #endregion

}
