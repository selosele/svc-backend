using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using svc.App.Common.Auth.Services;
using svc.App.Human.Employee.Models.DTO;
using svc.App.Human.Employee.Services;
using svc.App.Shared.Utils;

namespace svc.App.Human.Employee.Controllers;

/// <summary>
/// 직원 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/human/employees")]
public class EmployeeController : ControllerBase
{
    #region Fields
    private readonly AuthService _authService;
    private readonly EmployeeService _employeeService;
    #endregion
    
    #region Constructor
    public EmployeeController(
        AuthService authService,
        EmployeeService employeeService
    ) {
        _authService = authService;
        _employeeService = employeeService;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 직원을 조회한다.
    /// </summary>
    [HttpGet("{employeeId}")]
    [Authorize]
    public async Task<ActionResult<EmployeeResponseDTO?>> GetEmployee(int employeeId)
        => Ok(await _employeeService.GetEmployee(new GetEmployeeRequestDTO { EmployeeId = employeeId }));

    /// <summary>
    /// 직원을 수정한다.
    /// </summary>
    [HttpPut("{employeeId}")]
    [Authorize]
    public async Task<ActionResult<EmployeeResponseDTO>> UpdateEmployee(int employeeId, [FromBody] UpdateEmployeeRequestDTO updateEmployeeRequestDTO)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        var myEmployeeId = int.Parse(user?.FindFirstValue(ClaimUtil.EMPLOYEE_ID_IDENTIFIER)!);

        if (employeeId != myEmployeeId)
            return NotFound();

        updateEmployeeRequestDTO.UpdaterId = myUserId;
        return Ok(await _employeeService.UpdateEmployee(updateEmployeeRequestDTO));
    }

    /// <summary>
    /// 직원 회사를 조회한다.
    /// </summary>
    [HttpGet("{employeeId}/companies/{employeeCompanyId}")]
    [Authorize]
    public async Task<ActionResult<EmployeeCompanyResponseDTO>> GetEmployeeCompany(int employeeId, int employeeCompanyId)
        => Ok(await _employeeService.GetEmployeeCompany(employeeCompanyId));
    #endregion

}
