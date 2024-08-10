using System.ComponentModel.DataAnnotations;
using svc.App.Shared.Models.DTO;

namespace svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 사용자 권한 추가 요청 DTO
/// </summary>
public record AddUserRoleRequestDTO : HttpRequestDTOBase
{
    #region Fields
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
    #endregion

}
