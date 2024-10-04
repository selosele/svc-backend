using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Notification.Models.DTO;

/// <summary>
/// 알림 수정/삭제 요청 DTO
/// </summary>
public record SaveNotificationRequestDTO : HttpRequestDTOBase
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
    
    /// <summary>
    /// 알림 종류 코드
    /// </summary>
    public string? NotificationKindCode { get; set; }
    #endregion

}