using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Notification.Models.DTO;
using Svc.App.Common.Notification.Services;
using Svc.App.Common.Auth.Services;

namespace Svc.App.Common.Notification.Controllers;

/// <summary>
/// 알림 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/co/notifications")]
public class NotificationController : ControllerBase
{
    #region [필드]
    private readonly AuthService _authService;
    private readonly NotificationService _notificationService;
    #endregion
    
    #region [생성자]
    public NotificationController(
        AuthService authService,
        NotificationService notificationService
    ) {
        _authService = authService;
        _notificationService = notificationService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 알림 개수 및 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<NotificationResponseDTO>> ListAndCountNotification([FromQuery] GetNotificationRequestDTO? dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto!.UserId = user.UserId;

        var count = await _notificationService.CountNotification(dto);
        var list = await _notificationService.ListNotification(dto);

        return Ok(new NotificationResponseDTO { NotificationTotal = count, NotificationList = list });
    }

    /// <summary>
    /// 알림을 확인처리한다.
    /// </summary>
    [HttpPut("{notificationId}")]
    [Authorize]
    public async Task<ActionResult<int>> UpdateNotificationReadDt(int notificationId, [FromBody] SaveNotificationRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.UpdaterId = user.UserId;

        return Ok(await _notificationService.UpdateNotificationReadDt(dto));
    }

    /// <summary>
    /// 알림을 삭제한다.
    /// </summary>
    [HttpDelete("{notificationId}")]
    [Authorize]
    public async Task<ActionResult> RemoveNotification(int notificationId)
    {
        var user = _authService.GetAuthenticatedUser();
        await _notificationService.RemoveNotification(new SaveNotificationRequestDTO
        {
            NotificationId = notificationId,
            UpdaterId = user.UserId
        });
        return NoContent();
    }
    #endregion

}
