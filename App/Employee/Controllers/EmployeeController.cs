using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using svc.App.Auth.Services;
using svc.App.Employee.Models.DTO;
using svc.App.Employee.Services;
using svc.App.Shared.Controllers;
using svc.App.Shared.Utils;

namespace svc.App.Employee.Controllers;

/// <summary>
/// 직원 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/[controller]s")]
public class EmployeeController : MyApiControllerBase<EmployeeController>
{
    #region Fields
    private readonly AuthService _authService;
    private readonly EmployeeService _employeeService;
    #endregion
    
    #region Constructor
    public EmployeeController(
        AuthService authService,
        EmployeeService employeeService,
        ILogger<EmployeeController> logger,
        IMapper mapper
    ) : base(logger, mapper)
    {
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
    public async Task<ActionResult<EmployeeResponseDTO>> ListCode(int employeeId)
    {
        // var user = _authService.GetAuthenticatedUser();
        // var myEmployeeId = int.Parse(user?.FindFirstValue(ClaimUtil.EmployeeIdIdentifier)!);

        // // 직원 ID 파라미터와 인증된 사용자의 직원 ID가 다르면 404 예외를 던진다.
        // if (employeeId != myEmployeeId)
        //     return NotFound();
        
        return Ok(await _employeeService.GetEmployee(new GetEmployeeRequestDTO { EmployeeId = employeeId }));
    }
    #endregion

}
