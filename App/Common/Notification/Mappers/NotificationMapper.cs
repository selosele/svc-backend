using SmartSql;
using Svc.App.Shared.Extensions;
using Svc.App.Common.Notification.Models.DTO;

namespace Svc.App.Common.Notification.Mappers;

/// <summary>
/// 알림 매퍼 클래스
/// </summary>
public class NotificationMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public NotificationMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 알림 개수를 조회한다.
    /// </summary>
    public Task<int> CountNotification(GetNotificationRequestDTO? dto)
        => SqlMapper.QueryForObject<int>(nameof(NotificationMapper), "CountNotification", dto);

    /// <summary>
    /// 알림 목록을 조회한다.
    /// </summary>
    public Task<IList<NotificationResultDTO>> ListNotification(GetNotificationRequestDTO? dto)
        => SqlMapper.QueryForList<NotificationResultDTO>(nameof(NotificationMapper), "ListNotification", dto);

    /// <summary>
    /// 알림을 추가한다.
    /// </summary>
    public Task<int> AddNotification(AddNotificationRequestDTO dto)
        => SqlMapper.ExecuteScalar<int>(nameof(NotificationMapper), "AddNotification", dto);

    /// <summary>
    /// 알림을 확인처리한다.
    /// </summary>
    public Task<int> UpdateNotificationReadDt(SaveNotificationRequestDTO dto)
        => SqlMapper.Execute(nameof(NotificationMapper), "UpdateNotificationReadDt", dto);

    /// <summary>
    /// 알림을 삭제한다.
    /// </summary>
    public Task<int> RemoveNotification(SaveNotificationRequestDTO dto)
        => SqlMapper.Execute(nameof(NotificationMapper), "RemoveNotification", dto);
    #endregion

}
