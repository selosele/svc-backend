using SmartSql.AOP;
using Svc.App.Common.Menu.Models.DTO;
using Svc.App.Common.Menu.Mappers;

namespace Svc.App.Common.Menu.Services;

/// <summary>
/// 메뉴 즐겨찾기 서비스 클래스
/// </summary>
public class MenuBookmarkService
{
    #region [필드]
    private readonly MenuBookmarkMapper _menuBookmarkMapper;
    #endregion
    
    #region [생성자]
    public MenuBookmarkService(
        MenuBookmarkMapper menuBookmarkMapper
    )
    {
        _menuBookmarkMapper = menuBookmarkMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 메뉴 즐겨찾기 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<MenuBookmarkResponseDTO>> ListMenuBookmark()
        => await _menuBookmarkMapper.ListMenuBookmark();

    /// <summary>
    /// 메뉴 즐겨찾기를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<MenuBookmarkResponseDTO> AddMenuBookmark(SaveMenuBookmarkRequestDTO dto)
    {
        var menuBookmarkId = await _menuBookmarkMapper.AddMenuBookmark(dto);
        return await _menuBookmarkMapper.GetMenuBookmark(menuBookmarkId);
    }

    /// <summary>
    /// 메뉴 즐겨찾기를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveMenuBookmark(int menuBookmarkId)
        => await _menuBookmarkMapper.RemoveMenuBookmark(menuBookmarkId);
    #endregion
    
}

