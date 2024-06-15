using svc.App.Shared.Models.DTO;

namespace svc.App.Auth.Models.DTO;

/// <summary>
/// 사용자 권한 추가 요청 DTO
/// </summary>
public class AddUserRoleRequestDTO : MyRequestDTOBase
{
    /// <summary>
    /// 권한 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 권한 ID
    /// </summary>
    public string? RoleId { get; set; }

}
