using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Notification.Models.DTO;

/// <summary>
/// 알림 조회 요청 DTO
/// </summary>
public record GetNotificationRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 알림 ID
    /// </summary>
    public int? NotificationId { get; set; }
    
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }
    #endregion

}