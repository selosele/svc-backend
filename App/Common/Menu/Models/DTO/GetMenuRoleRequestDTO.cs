using svc.App.Shared.Models.DTO;

namespace svc.App.Common.Menu.Models.DTO;

/// <summary>
/// 메뉴 권한 조회 요청 DTO
/// </summary>
public record GetMenuRoleRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }
    #endregion

}
