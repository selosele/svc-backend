using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Human.Department.Models.DTO;
using Svc.App.Human.Department.Services;

namespace Svc.App.Human.Department.Controllers;

/// <summary>
/// 부서 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/human/departments")]
public class DepartmentController : ControllerBase
{
    #region Fields
    private readonly DepartmentService _departmentService;
    #endregion
    
    #region Constructor
    public DepartmentController(
        DepartmentService departmentService
    ) {
        _departmentService = departmentService;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 부서 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<DepartmentResponseDTO>>> ListDepartment([FromQuery] GetDepartmentRequestDTO? getDepartmentRequestDTO)
        => Ok(await _departmentService.ListDepartment(getDepartmentRequestDTO));
    #endregion

}
