using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 설정 추가 요청 DTO
/// </summary>
public record AddUserSetupRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 사이트타이틀명
    /// </summary>
    public string? SiteTitleName { get; set; }
    #endregion

}
