using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Role.Models.DTO;
using Svc.App.Common.Role.Services;

namespace Svc.App.Common.Role.Controllers;

/// <summary>
/// 권한 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("co/roles")]
public class RoleController : ControllerBase
{
    #region [필드]
    private readonly RoleService _roleService;
    #endregion
    
    #region [생성자]
    public RoleController(
        RoleService roleService
    ) {
        _roleService = roleService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 권한 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<RoleResponseDTO>> ListRole()
    {
        var roleList = await _roleService.ListRole();
        return Ok(new RoleResponseDTO { RoleList = roleList });
    }
    #endregion

}
