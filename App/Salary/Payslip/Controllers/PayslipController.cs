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

        var payslipList = await _payslipService.ListPayslip(dto);

        return Ok(new PayslipResponseDTO { PayslipList = payslipList });
    }

    /// <summary>
    /// 급여명세서를 조회한다.
    /// </summary>
    [HttpGet("{payslipId}")]
    [Authorize]
    public async Task<ActionResult<List<PayslipResponseDTO>>> GetPayslip(int payslipId, [FromQuery] GetPayslipRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;
        
        if (myUserId != dto.UserId)
            return NotFound();

        var payslip = await _payslipService.GetPayslip(dto);
        var payslipList = await _payslipService.ListPrevNextPayslip(dto);

        return Ok(new PayslipResponseDTO { Payslip = payslip, PayslipList = payslipList });
    }

    /// <summary>
    /// 급여명세서를 추가한다.
    /// </summary>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<PayslipResponseDTO>> AddPayslip([FromBody] SavePayslipRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;
        var myEmloyeeId = user.Employee?.EmployeeId;
        
        if (myUserId != dto.UserId)
            return NotFound();

        dto.EmployeeId = myEmloyeeId;
        dto.CreaterId = myUserId;
        
        var payslip = await _payslipService.AddPayslip(dto);

        return Created(string.Empty, new PayslipResponseDTO { Payslip = payslip });
    }

    /// <summary>
    /// 급여명세서를 수정한다.
    /// </summary>
    [HttpPut("{payslipId}")]
    [Authorize]
    public async Task<ActionResult<PayslipResponseDTO>> UpdatePayslip(int payslipId, [FromBody] SavePayslipRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;
        var myEmloyeeId = user.Employee?.EmployeeId;
        
        if (myUserId != dto.UserId)
            return NotFound();

        dto.EmployeeId = myEmloyeeId;
        dto.CreaterId = myUserId;
        dto.UpdaterId = myUserId;
        
        var payslip = await _payslipService.UpdatePayslip(dto);

        return Ok(new PayslipResponseDTO { Payslip = payslip });
    }

    /// <summary>
    /// 급여명세서를 삭제한다.
    /// </summary>
    [HttpDelete("{payslipId}")]
    [Authorize]
    public async Task<ActionResult> RemoveArticle(int payslipId)
    {
        var user = _authService.GetAuthenticatedUser();
        var payslip = await _payslipService.GetPayslip(new GetPayslipRequestDTO { PayslipId = payslipId });

        if (payslip.EmployeeId != user.Employee?.EmployeeId)
            return NotFound();

        await _payslipService.RemovePayslip(payslipId, user.UserId);
        return NoContent();
    }
    #endregion

}
