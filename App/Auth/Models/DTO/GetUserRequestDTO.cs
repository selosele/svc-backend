using System.ComponentModel.DataAnnotations;
using svc.App.Shared.Models.DTO;

namespace svc.App.Auth.Models.DTO;

/// <summary>
/// 사용자 조회 요청 DTO
/// </summary>
public record GetUserRequestDTO : MyRequestDTOBase
{
    /// <summary>
    /// 사용자 계정
    /// </summary>
    public string? UserAccount { get; set; }

    /// <summary>
    /// 사용자 비밀번호
    /// </summary>
    public string? UserPassword { get; set; }

    /// <summary>
    /// 사용자 명
    /// </summary>
    [StringLength(10)]
    public string? UserName { get; set; }
    
}
