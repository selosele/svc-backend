using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Notification.Models.DTO;

/// <summary>
/// 알림 수정 요청 DTO
/// </summary>
public record UpdateNotificationRequestDTO : HttpRequestDTOBase
{
    #region Fields
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