using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Notification.Models.DTO;

/// <summary>
/// 알림 추가 요청 DTO
/// </summary>
public record AddNotificationRequestDTO : HttpRequestDTOBase
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
    /// 알림 제목
    /// </summary>
    public string? NotificationTitle { get; set; }
    
    /// <summary>
    /// 알림 내용
    /// </summary>
    public string? NotiticationContent
    {
        get => _notificationContent;
        set => _notificationContent = value?.Trim();
    }
    private string? _notificationContent;
    
    /// <summary>
    /// 알림 유형 코드
    /// </summary>
    public string? NotificationTypeCode { get; set; }
    
    /// <summary>
    /// 알림 종류 코드
    /// </summary>
    public string? NotificationKindCode { get; set; }
    
    /// <summary>
    /// 알림 확인일시
    /// </summary>
    public string? NotificationReadDt { get; set; }
    #endregion

}