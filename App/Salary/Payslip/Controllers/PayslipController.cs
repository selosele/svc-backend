using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Services;
using Svc.App.Salary.Payslip.Models.DTO;
using Svc.App.Salary.Payslip.Services;

namespace Svc.App.Salary.Payslip.Controllers;

/// <summary>
/// 급여명세서 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/sa/payslips")]
public class PayslipController : ControllerBase
{
    #region [필드]
    private readonly AuthService _authService;
    private readonly PayslipService _payslipService;
    #endregion
    
    #region [생성자]
    public PayslipController(
        AuthService authService,
        PayslipService payslipService
    ) {
        _authService = authService;
        _payslipService = payslipService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 급여명세서 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<PayslipResponseDTO>>> ListPayslip([FromQuery] GetPayslipRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;
        
        if (myUserId != dto.UserId)
            return NotFound();

        return Ok(await _payslipService.ListPayslip(dto));
    }
    #endregion

}
