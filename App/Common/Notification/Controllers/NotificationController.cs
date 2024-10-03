using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Svc.App.Common.Notification.Models.DTO;
using Svc.App.Common.Notification.Services;
using Svc.App.Shared.Utils;
using Svc.App.Common.Auth.Services;

namespace Svc.App.Common.Notification.Controllers;

/// <summary>
/// 알림 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/common/notifications")]
public class NotificationController : ControllerBase
{
    #region Fields
    private readonly AuthService _authService;
    private readonly NotificationService _notificationService;
    #endregion
    
    #region Constructor
    public NotificationController(
        AuthService authService,
        NotificationService notificationService
    ) {
        _authService = authService;
        _notificationService = notificationService;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 알림 개수 및 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<NotificationResponseDTO>> ListAndCountNotification([FromQuery] GetNotificationRequestDTO? dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto!.UserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);

        return Ok(await _notificationService.ListAndCountNotification(dto));
    }

    /// <summary>
    /// 알림을 확인처리한다.
    /// </summary>
    [HttpPut("{notificationId}")]
    [Authorize]
    public async Task<ActionResult<int>> UpdateNotificationReadDt(int notificationId, [FromBody] SaveNotificationRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.UpdaterId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);

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
        await _notificationService.UpdateNotificationReadDt(new SaveNotificationRequestDTO
        {
            NotificationId = notificationId,
            UpdaterId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!)
        });
        return NoContent();
    }
    #endregion

}
