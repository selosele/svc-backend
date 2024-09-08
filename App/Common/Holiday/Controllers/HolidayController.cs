using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Holiday.Services;
using Svc.App.Common.Holiday.Models.DTO;
using Svc.App.Shared.Utils;

namespace Svc.App.Common.Holiday.Controllers;

/// <summary>
/// 휴일 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/common/holidays")]
public class HolidayController : ControllerBase
{
    #region Fields
    private readonly HolidayService _holidayService;
    #endregion
    
    #region Constructor
    public HolidayController(
        HolidayService holidayService
    ) {
        _holidayService = holidayService;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 휴일 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<List<HolidayResponseDTO>>> ListHoliday([FromQuery] GetHolidayRequestDTO? dto)
        => Ok(await _holidayService.ListHoliday(dto));

    /// <summary>
    /// 휴일을 조회한다.
    /// </summary>
    [HttpGet("{ymd}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<List<HolidayResponseDTO>>> GetHoliday(string ymd)
        => Ok(await _holidayService.GetHoliday(ymd));
    #endregion

}
