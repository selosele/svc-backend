using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using svc.App.Common.Menu.Models.DTO;
using svc.App.Common.Menu.Services;

namespace svc.App.Common.Menu.Controllers;

/// <summary>
/// 메뉴 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/common/menus")]
public class MenuController : ControllerBase
{
    #region Fields
    private readonly MenuService _menuService;
    #endregion
    
    #region Constructor
    public MenuController(
        MenuService menuService
    ) {
        _menuService = menuService;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<MenuResponseDTO>>> ListCode([FromQuery] GetMenuRequestDTO getMenuRequestDTO)
        => Ok(await _menuService.ListMenu(getMenuRequestDTO));
    #endregion

}
