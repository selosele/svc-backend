using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Services;
using Svc.App.Human.Employee.Models.DTO;
using Svc.App.Human.Employee.Services;

namespace Svc.App.Human.Employee.Controllers;

/// <summary>
/// 직원 API
/// </summary>
[ApiController]
[Route("api/hm/employees")]
public class EmployeeController(
    AuthService authService,
    EmployeeService employeeService
    ) : ControllerBase
{
    #region [필드]
    private readonly AuthService _authService = authService;
    private readonly EmployeeService _employeeService = employeeService;
    #endregion

    #region [메서드]
    /// <summary>
    /// 직원을 조회한다.
    /// </summary>
    [HttpGet("{employeeId}")]
    [Authorize]
    public async Task<ActionResult<EmployeeResponseDTO?>> GetEmployee(int employeeId)
    {
        var user = _authService.GetAuthenticatedUser();
        var myEmployeeId = user.Employee?.EmployeeId;

        if (employeeId != myEmployeeId)
            return NotFound();
        
        var employee = await _employeeService.GetEmployee(new GetEmployeeRequestDTO { EmployeeId = employeeId });
        return Ok(new EmployeeResponseDTO { Employee = employee });
    }

    /// <summary>
    /// 직원을 수정한다.
    /// </summary>
    [HttpPut("{employeeId}")]
    [Authorize]
    public async Task<ActionResult<EmployeeResponseDTO>> UpdateEmployee(int employeeId, [FromBody] UpdateEmployeeRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myEmployeeId = user.Employee?.EmployeeId;

        if (employeeId != myEmployeeId)
            return NotFound();

        dto.UpdaterId = user.UserId;

        var employee = await _employeeService.UpdateEmployee(dto);
        return Ok(new EmployeeResponseDTO { Employee = employee });
    }

    /// <summary>
    /// 근무이력 목록을 조회한다.
    /// </summary>
    [HttpGet("{employeeId}/companies")]
    [Authorize]
    public async Task<ActionResult<WorkHistoryResponseDTO>> ListWorkHistory(int employeeId, [FromQuery] GetWorkHistoryRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myEmployeeId = user.Employee?.EmployeeId;
        
        if (employeeId != myEmployeeId)
            return NotFound();

        dto.UserId = user.UserId;

        var workHistoryList = await _employeeService.ListWorkHistory(dto);
        return Ok(new WorkHistoryResponseDTO { WorkHistoryList = workHistoryList });
    }
    
    /// <summary>
    /// 근무이력을 조회한다.
    /// </summary>
    [HttpGet("{employeeId}/companies/{workHistoryId}")]
    [Authorize]
    public async Task<ActionResult<WorkHistoryResponseDTO>> GetWorkHistory(int employeeId, int workHistoryId)
    {
        var user = _authService.GetAuthenticatedUser();
        var myEmployeeId = user.Employee?.EmployeeId;

        if (employeeId != myEmployeeId)
            return NotFound();
        
        var workHistory = await _employeeService.GetWorkHistory(new GetWorkHistoryRequestDTO { WorkHistoryId = workHistoryId });
        return Ok(new WorkHistoryResponseDTO { WorkHistory = workHistory });
    }

    /// <summary>
    /// 최신 근무이력을 조회한다.
    /// </summary>
    [HttpGet("{employeeId}/companies/current")]
    [Authorize]
    public async Task<ActionResult<WorkHistoryResponseDTO>> GetCurrentWorkHistory(int employeeId)
    {
        var user = _authService.GetAuthenticatedUser();
        var myEmployeeId = user.Employee?.EmployeeId;

        if (employeeId != myEmployeeId)
            return NotFound();
        
        var workHistory = await _employeeService.GetCurrentWorkHistory(new GetWorkHistoryRequestDTO { EmployeeId = employeeId });
        return Ok(new WorkHistoryResponseDTO { WorkHistory = workHistory });
    }

    /// <summary>
    /// 근무이력을 추가한다.
    /// </summary>
    [HttpPost("{employeeId}/companies")]
    [Authorize]
    public async Task<ActionResult<WorkHistoryResponseDTO>> AddWorkHistory(int employeeId, [FromBody] SaveWorkHistoryRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myEmployeeId = user.Employee?.EmployeeId;

        if (employeeId != myEmployeeId)
            return NotFound();

        dto.EmployeeId = myEmployeeId;
        dto.CreaterId = user.UserId;
        dto.UpdaterId = user.UserId;

        var workHistory = await _employeeService.AddWorkHistory(dto);
        return Created(string.Empty, new WorkHistoryResponseDTO { WorkHistory = workHistory });
    }

    /// <summary>
    /// 근무이력을 수정한다.
    /// </summary>
    [HttpPut("{employeeId}/companies/{workHistoryId}")]
    [Authorize]
    public async Task<ActionResult<int>> UpdateWorkHistory(int employeeId, int workHistoryId, [FromBody] SaveWorkHistoryRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        var myEmployeeId = user.Employee?.EmployeeId;

        if (employeeId != myEmployeeId)
            return NotFound();

        dto.EmployeeId = myEmployeeId;
        dto.CreaterId = user.UserId;
        dto.UpdaterId = user.UserId;

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
        var myUserId = user.UserId;
        var myEmployeeId = user.Employee?.EmployeeId;

        if (employeeId != myEmployeeId)
            return NotFound();

        await _employeeService.RemoveWorkHistory(new GetWorkHistoryRequestDTO
        {
            UserId = myUserId,
            EmployeeId = myEmployeeId,
            WorkHistoryId = workHistoryId
        });

        return NoContent();
    }
    #endregion

}
