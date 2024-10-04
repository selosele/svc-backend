using SmartSql;
using Svc.App.Common.Notification.Models.DTO;

namespace Svc.App.Common.Notification.Repositories;

/// <summary>
/// 알림 리포지토리 클래스
/// </summary>
public class NotificationRepository : INotificationRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public NotificationRepository(ISqlMapper sqlMapper)
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
            Scope = nameof(NotificationRepository),
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
            Scope = nameof(NotificationRepository),
            SqlId = "ListNotification",
            Request = dto
        });
    }

    /// <summary>
    /// 알림을 추가한다.
    /// </summary>
    public Task<int> AddNotification(AddNotificationRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(NotificationRepository),
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
            Scope = nameof(NotificationRepository),
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
            Scope = nameof(NotificationRepository),
            SqlId = "RemoveNotification",
            Request = dto
        });
    }
    #endregion

}
