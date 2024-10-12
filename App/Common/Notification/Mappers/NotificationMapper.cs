using SmartSql;
using Svc.App.Common.Notification.Models.DTO;

namespace Svc.App.Common.Notification.Mappers;

/// <summary>
/// 알림 매퍼 클래스
/// </summary>
public class NotificationMapper
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public NotificationMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 알림 개수를 조회한다.
    /// </summary>
    public Task<int> CountNotification(GetNotificationRequestDTO? dto)
    {
        return SqlMapper.QuerySingleAsync<int>(new RequestContext
        {
            Scope = nameof(NotificationMapper),
            SqlId = "CountNotification",
            Request = dto
        });
    }

    /// <summary>
    /// 알림 목록을 조회한다.
    /// </summary>
    public Task<IList<NotificationResultDTO>> ListNotification(GetNotificationRequestDTO? dto)
    {
        return SqlMapper.QueryAsync<NotificationResultDTO>(new RequestContext
        {
            Scope = nameof(NotificationMapper),
            SqlId = "ListNotification",
            Request = dto
        });
    }

    /// <summary>
    /// 알림을 추가한다.
    /// </summary>
    public Task<int> AddNotification(AddNotificationRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<int>(new RequestContext
        {
            Scope = nameof(NotificationMapper),
            SqlId = "AddNotification",
            Request = dto
        });
    }

    /// <summary>
    /// 알림을 확인처리한다.
    /// </summary>
    public Task<int> UpdateNotificationReadDt(SaveNotificationRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(NotificationMapper),
            SqlId = "UpdateNotificationReadDt",
            Request = dto
        });
    }

    /// <summary>
    /// 알림을 삭제한다.
    /// </summary>
    public Task<int> RemoveNotification(SaveNotificationRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(NotificationMapper),
            SqlId = "RemoveNotification",
            Request = dto
        });
    }
    #endregion

}
