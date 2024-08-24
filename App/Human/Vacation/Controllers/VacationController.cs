using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Human.Vacation.Models.DTO;
using Svc.App.Human.Vacation.Services;

namespace Svc.App.Human.Vacation.Controllers;

/// <summary>
/// 휴가 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/human/vacations")]
public class VacationController : ControllerBase
{
    #region Fields
    private readonly VacationService _vacationService;
    #endregion
    
    #region Constructor
    public VacationController(
        VacationService vacationService
    ) {
        _vacationService = vacationService;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 휴가 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<VacationResponseDTO>>> ListVacation([FromQuery] GetVacationRequestDTO getVacationRequestDTO)
        => Ok(await _vacationService.ListVacation(getVacationRequestDTO));
    #endregion

}
