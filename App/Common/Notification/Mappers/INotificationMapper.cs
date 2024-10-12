using Svc.App.Common.Notification.Models.DTO;

namespace Svc.App.Common.Notification.Mappers;

/// <summary>
/// 알림 매퍼 인터페이스
/// </summary>
public interface INotificationMapper
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
    /// 알림을 추가한다.
    /// </summary>
    Task<int> AddNotification(AddNotificationRequestDTO dto);

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
