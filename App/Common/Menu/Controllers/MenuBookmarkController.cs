using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Menu.Models.DTO;
using Svc.App.Common.Menu.Services;
using Svc.App.Common.Auth.Services;

namespace Svc.App.Common.Menu.Controllers;

/// <summary>
/// 메뉴 즐겨찾기 API
/// </summary>
[ApiController]
[Route("api/co/menubookmarks")]
public class MenuBookmarkController(
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
    /// 메뉴 즐겨찾기 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<MenuBookmarkResponseDTO>> ListMenuBookmark()
    {
        var user = _authService.GetAuthenticatedUser();
        var menuBookmarkList = await _menuService.ListMenuBookmark(user.UserId);

        return Ok(new MenuBookmarkResponseDTO { MenuBookmarkList = menuBookmarkList });
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

        var menuBookmark = await _menuService.AddMenuBookmark(dto);

        return Created(string.Empty, new MenuBookmarkResponseDTO { MenuBookmark = menuBookmark });
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
