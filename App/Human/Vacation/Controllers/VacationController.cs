using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Svc.App.Common.Auth.Services;
using Svc.App.Human.Vacation.Models.DTO;
using Svc.App.Human.Vacation.Services;
using Svc.App.Shared.Utils;

namespace Svc.App.Human.Vacation.Controllers;

/// <summary>
/// 휴가 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/human/vacations")]
public class VacationController : ControllerBase
{
    #region Fields
    private readonly AuthService _authService;
    private readonly VacationService _vacationService;
    #endregion
    
    #region Constructor
    public VacationController(
        AuthService authService,
        VacationService vacationService
    ) {
        _authService = authService;
        _vacationService = vacationService;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 휴가 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<VacationResponseDTO>>> ListVacation([FromQuery] GetVacationRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);

        dto.UserId = myUserId;
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
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        var myEmployeeId = int.Parse(user?.FindFirstValue(ClaimUtil.EMPLOYEE_ID_IDENTIFIER)!);

        dto.CreaterId = myUserId;
        dto.EmployeeId = myEmployeeId;
        
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
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        
        dto.UpdaterId = myUserId;
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
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);

        await _vacationService.RemoveVacation(vacationId, myUserId);
        return NoContent();
    }
    #endregion

}
