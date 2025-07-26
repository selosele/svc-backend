using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Role.Models.DTO;
using Svc.App.Common.Role.Services;

namespace Svc.App.Common.Role.Controllers;

/// <summary>
/// 권한 API
/// </summary>
[ApiController]
[Route("api/co/roles")]
public class RoleController(RoleService roleService) : ControllerBase
{
    #region [필드]
    private readonly RoleService _roleService = roleService;
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
