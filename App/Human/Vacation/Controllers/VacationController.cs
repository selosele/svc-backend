using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Services;
using Svc.App.Human.Vacation.Models.DTO;
using Svc.App.Human.Vacation.Services;

namespace Svc.App.Human.Vacation.Controllers;

/// <summary>
/// 휴가 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/hm/vacations")]
public class VacationController : ControllerBase
{
    #region [필드]
    private readonly AuthService _authService;
    private readonly VacationService _vacationService;
    #endregion
    
    #region [생성자]
    public VacationController(
        AuthService authService,
        VacationService vacationService
    ) {
        _authService = authService;
        _vacationService = vacationService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 휴가 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<VacationResponseDTO>>> ListVacation([FromQuery] GetVacationRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;
        
        if (myUserId != dto.UserId)
            return NotFound();

        return Ok(await _vacationService.ListVacation(dto));
    }

    /// <summary>
    /// 휴가를 조회한다.
    /// </summary>
    [HttpGet("{vacationId}")]
    [Authorize]
    public async Task<ActionResult<VacationResponseDTO>> GetVacation(int vacationId)
        => Ok(await _vacationService.GetVacation(vacationId));

    /// <summary>
    /// 휴가를 추가한다.
    /// </summary>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<VacationResponseDTO>> AddVacation([FromBody] SaveVacationRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();

        dto.CreaterId = user.UserId;
        dto.EmployeeId = user.Employee?.EmployeeId;

        return Created(string.Empty, await _vacationService.AddVacation(dto));
    }

    /// <summary>
    /// 휴가를 수정한다.
    /// </summary>
    [HttpPut("{vacationId}")]
    [Authorize]
    public async Task<ActionResult<int>> UpdateVacation(int vacationId, [FromBody] SaveVacationRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.UpdaterId = user.UserId;
        return await _vacationService.UpdateVacation(dto);
    }

    /// <summary>
    /// 휴가를 삭제한다.
    /// </summary>
    [HttpDelete("{vacationId}")]
    [Authorize]
    public async Task<ActionResult> RemoveVacation(int vacationId)
    {
        var user = _authService.GetAuthenticatedUser();
        await _vacationService.RemoveVacation(vacationId, user.UserId);
        return NoContent();
    }

    /// <summary>
    /// 휴가 계산 설정 목록을 조회한다.
    /// </summary>
    [HttpGet("calcs/{workHistoryId}")]
    [Authorize]
    public async Task<ActionResult<List<VacationCalcResponseDTO>>> ListVacationCalc(int workHistoryId)
        => Ok(await _vacationService.ListVacationCalc(workHistoryId));

    /// <summary>
    /// 휴가 계산 설정을 추가한다.
    /// </summary>
    [HttpPost("calcs/{workHistoryId}")]
    [Authorize]
    public async Task<ActionResult<int>> AddVacationCalc(int workHistoryId, [FromBody] AddVacationCalcRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myEmployeeId = user.Employee?.EmployeeId;

        dto.EmployeeId = myEmployeeId;
        dto.CreaterId = user.UserId;

        return Created(string.Empty, await _vacationService.AddVacationCalc(dto));
    }

    /// <summary>
    /// 휴가 통계 목록을 조회한다.
    /// </summary>
    [HttpGet("stats")]
    [Authorize]
    public async Task<ActionResult<List<VacationStatsResponseDTO>>> ListVacationStats([FromQuery] GetVacationStatsRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;
        var myWorkHistoryId = user.Employee!.WorkHistories![0].WorkHistoryId;

        if (dto.UserId != myUserId)
            return NotFound();

        var statsList = _vacationService.ListVacationStats(dto);
        var countInfo = _vacationService.GetVacationCountInfo(new GetVacationCountInfoRequestDTO { UserId = myUserId, WorkHistoryId = myWorkHistoryId });
        var vacationList = _vacationService.ListVacation(new GetVacationRequestDTO { WorkHistoryId = myWorkHistoryId });

        // 여러 개의 비동기 작업을 병렬로 실행
        await Task.WhenAll(statsList, countInfo, vacationList);

        return Ok(new VacationStatsResponseDTO
        {
            StatsList = await statsList,
            CountInfo = await countInfo,
            VacationList = await vacationList
        });
    }

    /// <summary>
    /// 월별 휴가사용일수 목록을 조회한다.
    /// </summary>
    [HttpGet("stats/month")]
    [Authorize]
    public async Task<ActionResult<List<VacationByMonthResponseDTO>>> ListVacationByMonth([FromQuery] GetVacationByMonthRequestDTO dto)
        => Ok(await _vacationService.ListVacationByMonth(dto));
    #endregion

}
