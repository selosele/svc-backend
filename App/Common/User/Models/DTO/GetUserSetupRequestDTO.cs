using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 설정 조회 요청 DTO
/// </summary>
public record GetUserSetupRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 사용자 설정 ID
    /// </summary>
    public int? UserSetupId { get; set; }

    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }
    #endregion
    
}
