using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Common.Notification.Models.DTO;

namespace Svc.App.Common.Notification.Mappers;

/// <summary>
/// 알림 매퍼
/// </summary>
public class NotificationMapper(ISqlMapper sqlMapper) : MyMapperBase(sqlMapper)
{
    #region [메서드]
    /// <summary>
    /// 알림 개수를 조회한다.
    /// </summary>
    public Task<int> CountNotification(GetNotificationRequestDTO? dto)
        => QueryForObject<int>($"{nameof(NotificationMapper)}.CountNotification", dto);

    /// <summary>
    /// 알림 목록을 조회한다.
    /// </summary>
    public Task<IList<NotificationResultDTO>> ListNotification(GetNotificationRequestDTO? dto)
        => QueryForList<NotificationResultDTO>($"{nameof(NotificationMapper)}.ListNotification", dto);

    /// <summary>
    /// 알림을 추가한다.
    /// </summary>
    public Task<int> AddNotification(AddNotificationRequestDTO dto)
        => ExecuteScalar<int>($"{nameof(NotificationMapper)}.AddNotification", dto);

    /// <summary>
    /// 알림을 확인처리한다.
    /// </summary>
    public Task<int> UpdateNotificationReadDt(SaveNotificationRequestDTO dto)
        => Execute($"{nameof(NotificationMapper)}.UpdateNotificationReadDt", dto);

    /// <summary>
    /// 알림을 삭제한다.
    /// </summary>
    public Task<int> RemoveNotification(SaveNotificationRequestDTO dto)
        => Execute($"{nameof(NotificationMapper)}.RemoveNotification", dto);
    #endregion

}
