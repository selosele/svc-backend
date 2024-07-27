using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using svc.App.Human.Employee.Models.DTO;
using svc.App.Human.Employee.Services;
using svc.App.Shared.Controllers;

namespace svc.App.Human.Employee.Controllers;

/// <summary>
/// 직원 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/human/[controller]s")]
public class EmployeeController : MyApiControllerBase<EmployeeController>
{
    #region Fields
    private readonly EmployeeService _employeeService;
    #endregion
    
    #region Constructor
    public EmployeeController(
        EmployeeService employeeService,
        ILogger<EmployeeController> logger,
        IMapper mapper
    ) : base(logger, mapper)
    {
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
    #endregion

}
