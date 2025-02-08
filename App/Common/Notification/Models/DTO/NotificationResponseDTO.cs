namespace Svc.App.Common.Notification.Models.DTO;

/// <summary>
/// 알림 응답 DTO
/// </summary>
public record NotificationResponseDTO
{
    #region [필드]
    /// <summary>
    /// 알림
    /// </summary>
    public NotificationResultDTO? Notification { get; set; }

    /// <summary>
    /// 알림 목록
    /// </summary>
    public IList<NotificationResultDTO>? NotificationList { get; set; }

    /// <summary>
    /// 알림 개수
    /// </summary>
    public int NotificationTotal { get; set; }
    #endregion

}