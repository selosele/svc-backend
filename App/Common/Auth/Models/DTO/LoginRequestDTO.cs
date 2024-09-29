using System.ComponentModel.DataAnnotations;
using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 로그인 요청 DTO
/// </summary>
public record LoginRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 사용자 계정
    /// </summary>
    [Required]
    public string? UserAccount { get; set; }

    /// <summary>
    /// 사용자 비밀번호
    /// </summary>
    [MaxLength(12)]
    public string? UserPassword { get; set; }

    /// <summary>
    /// 슈퍼로그인 여부
    /// </summary>
    public string? IsSuperLogin { get; set; }
    #endregion
}
