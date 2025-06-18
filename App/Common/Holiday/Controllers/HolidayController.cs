using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Holiday.Services;
using Svc.App.Common.Holiday.Models.DTO;
using Svc.App.Common.Auth.Services;

namespace Svc.App.Common.Holiday.Controllers;

/// <summary>
/// 휴일 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/co/holidays")]
public class HolidayController : ControllerBase
{
    #region [필드]
    private readonly AuthService _authService;
    private readonly HolidayService _holidayService;
    #endregion
    
    #region [생성자]
    public HolidayController(
        AuthService authService,
        HolidayService holidayService
    ) {
        _authService = authService;
        _holidayService = holidayService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 휴일 목록을 조회한다.
    /// </summary>
    [HttpGet("{userId}")]
    [Authorize]
    public async Task<ActionResult<HolidayResponseDTO>> ListHoliday(int userId, [FromQuery] GetHolidayRequestDTO? dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;

        if (userId != myUserId)
            return NotFound();

        dto!.UserId = myUserId;

        var holidayList = await _holidayService.ListHoliday(dto);
        return Ok(new HolidayResponseDTO { HolidayList = holidayList });
    }

    /// <summary>
    /// 휴일을 조회한다.
    /// </summary>
    [HttpGet("{userId}/{ymd}")]
    [Authorize]
    public async Task<ActionResult<HolidayResponseDTO>> GetHoliday(int userId, string ymd)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;

        if (userId != myUserId)
            return NotFound();

        var holiday = await _holidayService.GetHoliday(new GetHolidayRequestDTO { YMD = ymd, UserId = myUserId });
        return Ok(new HolidayResponseDTO { Holiday = holiday });
    }

    /// <summary>
    /// 휴일을 추가한다.
    /// </summary>
    [HttpPost("{userId}")]
    [Authorize]
    public async Task<ActionResult<HolidayResponseDTO>> AddHoliday(int userId, [FromBody] SaveHolidayRequestDTO saveHolidayRequestDTO)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;

        if (userId != myUserId)
            return NotFound();

        saveHolidayRequestDTO.CreaterId = myUserId;

        var holiday = await _holidayService.AddHoliday(saveHolidayRequestDTO);
        return Created(string.Empty, new HolidayResponseDTO { Holiday = holiday });
    }

    /// <summary>
    /// 휴일을 수정한다.
    /// </summary>
    [HttpPut("{userId}/{ymd}")]
    [Authorize]
    public async Task<ActionResult<int>> UpdateHoliday(int userId, string ymd, [FromBody] SaveHolidayRequestDTO saveHolidayRequestDTO)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;

        if (userId != myUserId)
            return NotFound();

        saveHolidayRequestDTO.UpdaterId = myUserId;
        return Ok(await _holidayService.UpdateHoliday(saveHolidayRequestDTO));
    }

    /// <summary>
    /// 휴일을 삭제한다.
    /// </summary>
    [HttpDelete("{userId}/{ymd}")]
    [Authorize]
    public async Task<ActionResult> RemoveCode(int userId, string ymd)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;

        if (userId != myUserId)
            return NotFound();

        await _holidayService.RemoveHoliday(ymd, myUserId);
        return NoContent();
    }
    #endregion

}
