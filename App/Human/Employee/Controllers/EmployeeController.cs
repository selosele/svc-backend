using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Services;
using Svc.App.Human.Employee.Models.DTO;
using Svc.App.Human.Employee.Services;
using Svc.App.Shared.Utils;

namespace Svc.App.Human.Employee.Controllers;

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
        => Ok(await _employeeService.GetEmployeeCompany(new GetEmployeeCompanyRequestDTO { EmployeeCompanyId = employeeCompanyId }));

    /// <summary>
    /// 직원 회사를 추가한다.
    /// </summary>
    [HttpPost("{employeeId}/companies")]
    [Authorize]
    public async Task<ActionResult<int>> AddEmployeeCompany(int employeeId, [FromBody] SaveEmployeeCompanyRequestDTO saveEmployeeCompanyRequestDTO)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        var myEmployeeId = int.Parse(user?.FindFirstValue(ClaimUtil.EMPLOYEE_ID_IDENTIFIER)!);

        if (employeeId != myEmployeeId)
            return NotFound();

        saveEmployeeCompanyRequestDTO.EmployeeId = myEmployeeId;
        saveEmployeeCompanyRequestDTO.CreaterId = myUserId;

        return Created(string.Empty, await _employeeService.AddEmployeeCompany(saveEmployeeCompanyRequestDTO));
    }

    /// <summary>
    /// 직원 회사를 수정한다.
    /// </summary>
    [HttpPut("{employeeId}/companies/{employeeCompanyId}")]
    [Authorize]
    public async Task<ActionResult<int>> UpdateEmployeeCompany(int employeeId, int employeeCompanyId, [FromBody] SaveEmployeeCompanyRequestDTO saveEmployeeCompanyRequestDTO)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        var myEmployeeId = int.Parse(user?.FindFirstValue(ClaimUtil.EMPLOYEE_ID_IDENTIFIER)!);

        if (employeeId != myEmployeeId)
            return NotFound();

        saveEmployeeCompanyRequestDTO.UpdaterId = myUserId;

        return Ok(await _employeeService.UpdateEmployeeCompany(saveEmployeeCompanyRequestDTO));
    }

    /// <summary>
    /// 직원 회사를 삭제한다.
    /// </summary>
    [HttpDelete("{employeeId}/companies/{employeeCompanyId}")]
    [Authorize]
    public async Task<ActionResult> RemoveEmployeeCompany(int employeeId, int employeeCompanyId)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        var myEmployeeId = int.Parse(user?.FindFirstValue(ClaimUtil.EMPLOYEE_ID_IDENTIFIER)!);

        if (employeeId != myEmployeeId)
            return NotFound();

        await _employeeService.RemoveEmployeeCompany(myUserId, employeeCompanyId);
        return NoContent();
    }
    #endregion

}
