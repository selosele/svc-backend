using Microsoft.AspNetCore.Mvc;

namespace Svc.App.Common.HealthCheck.Controllers;

/// <summary>
/// 헬스체크 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/co/healthcheck")]
public class HealthCheckController : ControllerBase
{
    #region [메서드]
    /// <summary>
    /// 헬스체크를 한다.
    /// </summary>
    [HttpGet]
    public ActionResult HealthCheck()
        => Ok(new { Status = "Healthy", Timestamp = DateTime.UtcNow });
    #endregion

}
