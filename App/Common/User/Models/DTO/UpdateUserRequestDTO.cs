using System.ComponentModel.DataAnnotations;
using Svc.App.Human.Employee.Models.DTO;
using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 수정 요청 DTO
/// </summary>
public record UpdateUserRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 사용자 ID
    /// </summary>
    [Required]
    public int? UserId { get; set; }

    /// <summary>
    /// 사용자 계정
    /// </summary>
    public string? UserAccount { get; set; }

    /// <summary>
    /// 사용자 활성화 여부
    /// </summary>
    public string? UserActiveYn { get; set; }

    /// <summary>
    /// 동의 구분 코드
    /// </summary>
    public string? AgreeTypeCode { get; set; }

    /// <summary>
    /// 동의 여부
    /// </summary>
    public string? AgreeYn { get; set; }

    /// <summary>
    /// 권한 ID 목록
    /// </summary>
    public IList<string>? Roles { get; set; }

    /// <summary>
    /// 직원 정보
    /// </summary>
    public UpdateEmployeeRequestDTO? Employee { get; set; }

    /// <summary>
    /// 사용자 수정, 사용자 잠금설정, 사용자동의여부수정 구분 값
    /// </summary>
    public string? ActionType { get; set; }
    #endregion
}
