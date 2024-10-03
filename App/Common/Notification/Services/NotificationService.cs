using SmartSql.AOP;
using Svc.App.Common.Notification.Models.DTO;
using Svc.App.Common.Notification.Repositories;

namespace Svc.App.Common.Notification.Services;

/// <summary>
/// 알림 서비스 클래스
/// </summary>
public class NotificationService
{
    #region Fields
    private readonly INotificationRepository _notificationRepository;
    #endregion
    
    #region Constructor
    public NotificationService(
        INotificationRepository notificationRepository
    )
    {
        _notificationRepository = notificationRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 알림 개수 및 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<NotificationResponseDTO> ListAndCountNotification(GetNotificationRequestDTO? dto)
    {
        var count = await _notificationRepository.CountNotification(dto);
        var list = await _notificationRepository.ListNotification(dto);
        return new NotificationResponseDTO { Total = count, List = list };
    }

    /// <summary>
    /// 알림을 확인처리한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateNotificationReadDt(SaveNotificationRequestDTO dto)
        => await _notificationRepository.UpdateNotificationReadDt(dto);

    /// <summary>
    /// 알림을 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveNotification(SaveNotificationRequestDTO dto)
        => await _notificationRepository.RemoveNotification(dto);
    #endregion
    
}

