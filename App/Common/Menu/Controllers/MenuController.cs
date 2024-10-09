using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Menu.Models.DTO;
using Svc.App.Common.Menu.Services;
using Svc.App.Common.Auth.Services;

namespace Svc.App.Common.Menu.Controllers;

/// <summary>
/// 메뉴 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/co/menus")]
public class MenuController : ControllerBase
{
    #region Fields
    private readonly AuthService _authService;
    private readonly MenuService _menuService;
    #endregion
    
    #region Constructor
    public MenuController(
        AuthService authService,
        MenuService menuService
    ) {
        _authService = authService;
        _menuService = menuService;
    }
    #endregion

    #region Methods
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
    #endregion

}
