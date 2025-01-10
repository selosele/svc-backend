using SmartSql.AOP;
using Svc.App.Common.Menu.Models.DTO;
using Svc.App.Common.Menu.Mappers;

namespace Svc.App.Common.Menu.Services;

/// <summary>
/// 메뉴 서비스 클래스
/// </summary>
public class MenuService
{
    #region [필드]
    private readonly MenuMapper _menuMapper;
    private readonly MenuRoleMapper _menuRoleMapper;
    #endregion
    
    #region [생성자]
    public MenuService(
        MenuMapper menuMapper,
        MenuRoleMapper menuRoleMapper
    )
    {
        _menuMapper = menuMapper;
        _menuRoleMapper = menuRoleMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<MenuResponseDTO>> ListMenu(GetMenuRequestDTO dto)
        => await _menuMapper.ListMenu(dto);

    /// <summary>
    /// 메뉴를 조회한다.
    /// </summary>
    [Transaction]
    public async Task<MenuResponseDTO> GetMenu(int menuId)
    {
        var menu = await _menuMapper.GetMenu(menuId);
        menu.MenuRoles = await _menuRoleMapper.ListMenuRole(new GetMenuRoleRequestDTO { MenuId = menuId });
        return menu;
    }

    /// <summary>
    /// 메뉴를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveMenu(int menuId, int? updaterId)
        => await _menuMapper.RemoveMenu(menuId, updaterId);
    #endregion
    
}

