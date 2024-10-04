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
[Route("api/hm/employees")]
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
    public async Task<ActionResult<EmployeeResponseDTO>> UpdateEmployee(int employeeId, [FromBody] UpdateEmployeeRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        var myEmployeeId = int.Parse(user?.FindFirstValue(ClaimUtil.EMPLOYEE_ID_IDENTIFIER)!);

        if (employeeId != myEmployeeId)
            return NotFound();

        dto.UpdaterId = myUserId;
        return Ok(await _employeeService.UpdateEmployee(dto));
    }

    /// <summary>
    /// 근무이력 목록을 조회한다.
    /// </summary>
    [HttpGet("{employeeId}/companies")]
    [Authorize]
    public async Task<ActionResult<List<WorkHistoryResponseDTO>>> ListWorkHistory(int employeeId, [FromQuery] GetWorkHistoryRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        
        dto.UserId = myUserId;
        return Ok(await _employeeService.ListWorkHistory(dto));
    }
    
    /// <summary>
    /// 근무이력을 조회한다.
    /// </summary>
    [HttpGet("{employeeId}/companies/{workHistoryId}")]
    [Authorize]
    public async Task<ActionResult<WorkHistoryResponseDTO>> GetWorkHistory(int employeeId, int workHistoryId)
        => Ok(await _employeeService.GetWorkHistory(new GetWorkHistoryRequestDTO { WorkHistoryId = workHistoryId }));

    /// <summary>
    /// 근무이력을 추가한다.
    /// </summary>
    [HttpPost("{employeeId}/companies")]
    [Authorize]
    public async Task<ActionResult<int>> AddWorkHistory(int employeeId, [FromBody] SaveWorkHistoryRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        var myEmployeeId = int.Parse(user?.FindFirstValue(ClaimUtil.EMPLOYEE_ID_IDENTIFIER)!);

        if (employeeId != myEmployeeId)
            return NotFound();

        dto.EmployeeId = myEmployeeId;
        dto.CreaterId = myUserId;

        return Created(string.Empty, await _employeeService.AddWorkHistory(dto));
    }

    /// <summary>
    /// 근무이력을 수정한다.
    /// </summary>
    [HttpPut("{employeeId}/companies/{workHistoryId}")]
    [Authorize]
    public async Task<ActionResult<int>> UpdateWorkHistory(int employeeId, int workHistoryId, [FromBody] SaveWorkHistoryRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        var myEmployeeId = int.Parse(user?.FindFirstValue(ClaimUtil.EMPLOYEE_ID_IDENTIFIER)!);

        if (employeeId != myEmployeeId)
            return NotFound();

        dto.UpdaterId = myUserId;

        return Ok(await _employeeService.UpdateWorkHistory(dto));
    }

    /// <summary>
    /// 근무이력을 삭제한다.
    /// </summary>
    [HttpDelete("{employeeId}/companies/{workHistoryId}")]
    [Authorize]
    public async Task<ActionResult> RemoveWorkHistory(int employeeId, int workHistoryId)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        var myEmployeeId = int.Parse(user?.FindFirstValue(ClaimUtil.EMPLOYEE_ID_IDENTIFIER)!);

        if (employeeId != myEmployeeId)
            return NotFound();

        await _employeeService.RemoveWorkHistory(myUserId, workHistoryId);
        return NoContent();
    }
    #endregion

}
