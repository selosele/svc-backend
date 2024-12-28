namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 권한 응답 DTO
/// </summary>
public record UserSetupResponseDTO
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

    /// <summary>
    /// 사이트타이틀명
    /// </summary>
    public string? SiteTitleName { get; set; }
    #endregion

}
