using System.ComponentModel.DataAnnotations;
using Svc.App.Human.Employee.Models.DTO;
using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 사용자 수정 요청 DTO
/// </summary>
public record UpdateUserRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 사용자 ID
    /// </summary>
    [Required]
    public int? UserId { get; set; }

    /// <summary>
    /// 사용자 활성화 여부
    /// </summary>
    public string? UserActiveYn { get; set; }

    /// <summary>
    /// 권한 ID 목록
    /// </summary>
    public IList<string>? Roles { get; set; }

    /// <summary>
    /// 직원 정보
    /// </summary>
    public UpdateEmployeeRequestDTO? Employee { get; set; }
    #endregion
}
