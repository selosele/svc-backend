using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Menu.Models.DTO;
using Svc.App.Common.Menu.Services;
using Svc.App.Common.Auth.Services;
using Svc.App.Shared.Utils;

namespace Svc.App.Common.Menu.Controllers;

/// <summary>
/// 메뉴 컨트롤러
/// </summary>
[ApiController]
[Route("api/co/menus")]
public class MenuController(
    AuthService authService,
    MenuService menuService
    ) : ControllerBase
{
    #region [필드]
    private readonly AuthService _authService = authService;
    private readonly MenuService _menuService = menuService;
    #endregion

    #region [메서드]
    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<MenuResponseDTO>> ListMenu([FromQuery] GetMenuRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.UserId = user.UserId;
        dto.UseYn = "Y";

        var menuList = await _menuService.ListMenu(dto);
        return Ok(new MenuResponseDTO { MenuList = menuList });
    }

    /// <summary>
    /// 시스템관리 > 메뉴관리 > 메뉴 목록을 조회한다.
    /// </summary>
    [HttpGet("sys")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<MenuResponseDTO>> ListSysMenu([FromQuery] GetMenuRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.UserId = user.UserId;

        var menuList = await _menuService.ListMenu(dto);
        return Ok(new MenuResponseDTO { MenuList = menuList });
    }

    /// <summary>
    /// 메뉴를 조회한다.
    /// </summary>
    [HttpGet("{menuId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<MenuResponseDTO>> GetMenu(int menuId)
    {
        var menu = await _menuService.GetMenu(menuId);
        return Ok(new MenuResponseDTO { Menu = menu });
    }

    /// <summary>
    /// 메뉴를 추가한다.
    /// </summary>
    [HttpPost]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<MenuResponseDTO>> AddMenu([FromBody] SaveMenuRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.CreaterId = user.UserId;

        var menu = await _menuService.AddMenu(dto);
        return Created(string.Empty, new MenuResponseDTO { Menu = menu });
    }

    /// <summary>
    /// 메뉴를 수정한다.
    /// </summary>
    [HttpPut("{menuId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<MenuResponseDTO>> UpdateMenu(int menuId, [FromBody] SaveMenuRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.CreaterId = user.UserId;
        dto.UpdaterId = user.UserId;

        var menu = await _menuService.UpdateMenu(dto);
        return Ok(new MenuResponseDTO { Menu = menu });
    }

    /// <summary>
    /// 메뉴를 삭제한다.
    /// </summary>
    [HttpDelete("{menuId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult> RemoveMenu(int menuId)
    {
        var user = _authService.GetAuthenticatedUser();

        await _menuService.RemoveMenu(menuId, user.UserId);
        return NoContent();
    }
    #endregion

}
