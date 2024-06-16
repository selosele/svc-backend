using System.ComponentModel.DataAnnotations;
using svc.App.Shared.Models.DTO;

namespace svc.App.Auth.Models.DTO;

/// <summary>
/// 사용자 권한 추가 요청 DTO
/// </summary>
public class AddUserRoleRequestDTO : MyRequestDTOBase
{
    /// <summary>
    /// 사용자 ID
    /// </summary>
    [Required]
    public int? UserId { get; set; }

    /// <summary>
    /// 권한 ID
    /// </summary>
    [Required]
    public string? RoleId { get; set; }

}
