using System.ComponentModel.DataAnnotations;
using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 비밀번호 변경 요청 DTO
/// </summary>
public record UpdateUserPasswordRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 사용자 계정
    /// </summary>
    public string? UserAccount { get; set; }
    
    /// <summary>
    /// 현재 비밀번호
    /// </summary>
    [Required]
    [MaxLength(12)]
    public string? CurrentPassword { get; set; }

    /// <summary>
    /// 변경할 비밀번호
    /// </summary>
    [Required]
    [MaxLength(12)]
    public string? NewPassword { get; set; }

    /// <summary>
    /// 변경할 비밀번호 확인
    /// </summary>
    [Required]
    [MaxLength(12)]
    public string? NewPasswordConfirm { get; set; }

    /// <summary>
    /// 임시 비밀번호 발급 여부
    /// </summary>
    public string? TempPasswordYn { get; set; } = "N";
    #endregion

}
