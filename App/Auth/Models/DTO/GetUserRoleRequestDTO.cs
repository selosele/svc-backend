using svc.App.Shared.Models.DTO;

namespace svc.App.Auth.Models.DTO;

/// <summary>
/// 사용자 권한 조회 요청 DTO
/// </summary>
public record GetUserRoleRequestDTO : MyRequestDTOBase
{
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }
    
}
