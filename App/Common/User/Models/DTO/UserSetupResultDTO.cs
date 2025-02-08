namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 설정 조회 결과 DTO
/// </summary>
public record UserSetupResultDTO
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
