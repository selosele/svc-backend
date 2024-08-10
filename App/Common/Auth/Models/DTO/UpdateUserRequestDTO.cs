using svc.App.Shared.Models.DTO;

namespace svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 사용자 수정 요청 DTO
/// </summary>
public record UpdateUserRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 사용자 활성화 여부
    /// </summary>
    public string? UserActiveYn { get; set; }
    #endregion
}
