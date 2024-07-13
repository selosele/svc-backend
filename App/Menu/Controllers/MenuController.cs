using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using svc.App.Menu.Models.DTO;
using svc.App.Menu.Services;
using svc.App.Shared.Controllers;

namespace svc.App.Menu.Controllers;

/// <summary>
/// 메뉴 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/[controller]s")]
public class MenuController : MyApiControllerBase<MenuController>
{
    #region Fields
    private readonly MenuService _menuService;
    #endregion
    
    #region Constructor
    public MenuController(
        MenuService menuService,
        ILogger<MenuController> logger,
        IMapper mapper
    ) : base(logger, mapper)
    {
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
    {
        return Ok(await _menuService.ListMenu(getMenuRequestDTO));
    }
    #endregion

}
