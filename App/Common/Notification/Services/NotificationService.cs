using SmartSql.AOP;
using Svc.App.Common.Notification.Models.DTO;
using Svc.App.Common.Notification.Mappers;

namespace Svc.App.Common.Notification.Services;

/// <summary>
/// 알림 서비스 클래스
/// </summary>
public class NotificationService
{
    #region [필드]
    private readonly NotificationMapper _notificationMapper;
    #endregion
    
    #region [생성자]
    public NotificationService(
        NotificationMapper notificationMapper
    )
    {
        _notificationMapper = notificationMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 알림 개수를 조회한다.
    /// </summary>
    [Transaction]
    public async Task<int> CountNotification(GetNotificationRequestDTO? dto)
        => await _notificationMapper.CountNotification(dto);

    /// <summary>
    /// 알림 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<NotificationResultDTO>> ListNotification(GetNotificationRequestDTO? dto)
        => await _notificationMapper.ListNotification(dto);

    /// <summary>
    /// 알림을 확인처리한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateNotificationReadDt(SaveNotificationRequestDTO dto)
        => await _notificationMapper.UpdateNotificationReadDt(dto);

    /// <summary>
    /// 알림을 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveNotification(SaveNotificationRequestDTO dto)
        => await _notificationMapper.RemoveNotification(dto);
    #endregion
    
}

