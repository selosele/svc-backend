using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Models.DTO;
using Svc.App.Common.Auth.Services;

namespace Svc.App.Common.Auth.Controllers;

/// <summary>
/// 권한 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/co/roles")]
public class RoleController : ControllerBase
{
    #region Fields
    private readonly RoleService _roleService;
    #endregion
    
    #region Constructor
    public RoleController(
        RoleService roleService
    ) {
        _roleService = roleService;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 권한 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<RoleResponseDTO>>> ListRole()
        => Ok(await _roleService.ListRole());
    #endregion

}
