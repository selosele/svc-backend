using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Menu.Models.DTO;
using Svc.App.Common.Menu.Services;
using Svc.App.Common.Auth.Services;

namespace Svc.App.Common.Menu.Controllers;

/// <summary>
/// 메뉴 즐겨찾기 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/co/menubookmarks")]
public class MenuBookmarkController : ControllerBase
{
    #region [필드]
    private readonly AuthService _authService;
    private readonly MenuService _menuService;
    #endregion
    
    #region [생성자]
    public MenuBookmarkController(
        AuthService authService,
        MenuService menuService
    ) {
        _authService = authService;
        _menuService = menuService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 메뉴 즐겨찾기 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<MenuBookmarkResponseDTO>>> ListMenuBookmark()
    {
        var user = _authService.GetAuthenticatedUser();
        return Ok(await _menuService.ListMenuBookmark(user.UserId));
    }

    /// <summary>
    /// 메뉴 즐겨찾기를 추가한다.
    /// </summary>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<MenuBookmarkResponseDTO>> AddMenuBookmark([FromBody] SaveMenuBookmarkRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.CreaterId = user.UserId;

        return Created(string.Empty, await _menuService.AddMenuBookmark(dto));
    }

    /// <summary>
    /// 모든 메뉴 즐겨찾기를 삭제한다.
    /// </summary>
    [HttpDelete()]
    [Authorize]
    public async Task<ActionResult> RemoveMenuBookmarkAll()
    {
        var user = _authService.GetAuthenticatedUser();
        await _menuService.RemoveMenuBookmarkAll(user.UserId);
        return NoContent();
    }

    /// <summary>
    /// 메뉴 즐겨찾기를 삭제한다.
    /// </summary>
    [HttpDelete("{menuBookmarkId}")]
    [Authorize]
    public async Task<ActionResult> RemoveMenuBookmark(int menuBookmarkId)
    {
        await _menuService.RemoveMenuBookmark(menuBookmarkId);
        return NoContent();
    }
    #endregion

}
