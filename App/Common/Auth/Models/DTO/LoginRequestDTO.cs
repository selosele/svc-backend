using System.ComponentModel.DataAnnotations;
using svc.App.Shared.Models.DTO;

namespace svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 로그인 요청 DTO
/// </summary>
public record LoginRequestDTO : MyRequestDTOBase
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
    [Required]
    [MaxLength(12)]
    public string? UserPassword { get; set; }
    #endregion
}
