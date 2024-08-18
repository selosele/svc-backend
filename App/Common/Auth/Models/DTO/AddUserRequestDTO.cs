using System.ComponentModel.DataAnnotations;
using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 사용자 추가 요청 DTO
/// </summary>
public record AddUserRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 사용자 계정
    /// </summary>
    [Required]
    [MaxLength(20)]
    public string? UserAccount { get; set; }

    /// <summary>
    /// 사용자 비밀번호
    /// </summary>
    [Required]
    [MaxLength(12)]
    public string? UserPassword { get; set; }

    /// <summary>
    /// 사용자 활성화 여부
    /// </summary>
    public string? UserActiveYn { get; set; }

    /// <summary>
    /// 권한 ID 목록
    /// </summary>
    public List<string>? RoleIdList { get; set; }
    #endregion

}
