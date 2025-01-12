using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Menu.Models.DTO;
using Svc.App.Common.Menu.Services;
using Svc.App.Common.Auth.Services;
using Svc.App.Shared.Utils;

namespace Svc.App.Common.Menu.Controllers;

/// <summary>
/// 메뉴 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/co/menus")]
public class MenuController : ControllerBase
{
    #region [필드]
    private readonly AuthService _authService;
    private readonly MenuService _menuService;
    #endregion
    
    #region [생성자]
    public MenuController(
        AuthService authService,
        MenuService menuService
    ) {
        _authService = authService;
        _menuService = menuService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<MenuResponseDTO>>> ListMenu([FromQuery] GetMenuRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.UserId = user.UserId;

        return Ok(await _menuService.ListMenu(dto));
    }

    /// <summary>
    /// 시스템관리 > 메뉴관리 > 메뉴 목록을 조회한다.
    /// </summary>
    [HttpGet("sys")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<List<MenuResponseDTO>>> ListSysMenu([FromQuery] GetMenuRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.UserId = user.UserId;
        dto.UseYn = null; // 미사용 메뉴도 전부 조회

        return Ok(await _menuService.ListMenu(dto));
    }

    /// <summary>
    /// 메뉴를 조회한다.
    /// </summary>
    [HttpGet("{menuId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<MenuResponseDTO>> GetMenu(int menuId)
        => Ok(await _menuService.GetMenu(menuId));

    /// <summary>
    /// 메뉴를 추가한다.
    /// </summary>
    [HttpPost]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<MenuResponseDTO>> AddMenu([FromBody] SaveMenuRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.CreaterId = user.UserId;

        return Created(string.Empty, await _menuService.AddMenu(dto));
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

        return Ok(await _menuService.UpdateMenu(dto));
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
