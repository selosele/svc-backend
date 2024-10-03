using Svc.App.Common.Notification.Models.DTO;

namespace Svc.App.Common.Notification.Repositories;

/// <summary>
/// 알림 리포지토리 인터페이스
/// </summary>
public interface INotificationRepository
{
    #region Methods
    /// <summary>
    /// 알림 개수를 조회한다.
    /// </summary>
    Task<int> CountNotification(GetNotificationRequestDTO? dto);

    /// <summary>
    /// 알림 목록을 조회한다.
    /// </summary>
    Task<IList<NotificationResultDTO>> ListNotification(GetNotificationRequestDTO? dto);

    /// <summary>
    /// 알림을 확인처리한다.
    /// </summary>
    Task<int> UpdateNotificationReadDt(SaveNotificationRequestDTO dto);

    /// <summary>
    /// 알림을 삭제한다.
    /// </summary>
    Task<int> RemoveNotification(SaveNotificationRequestDTO dto);
    #endregion

}
