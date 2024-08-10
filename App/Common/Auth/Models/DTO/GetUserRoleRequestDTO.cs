using svc.App.Shared.Models.DTO;

namespace svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 사용자 권한 조회 요청 DTO
/// </summary>
public record GetUserRoleRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }
    #endregion
    
}
