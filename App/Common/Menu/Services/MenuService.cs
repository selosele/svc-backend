using SmartSql.AOP;
using Svc.App.Common.Menu.Models.DTO;
using Svc.App.Common.Menu.Mappers;
using Svc.App.Common.User.Mappers;
using Svc.App.Common.User.Models.DTO;

namespace Svc.App.Common.Menu.Services;

/// <summary>
/// 메뉴 서비스 클래스
/// </summary>
public class MenuService
{
    #region [필드]
    private readonly MenuMapper _menuMapper;
    private readonly MenuRoleMapper _menuRoleMapper;
    private readonly UserMapper _userMapper;
    private readonly UserMenuRoleMapper _userMenuRoleMapper;
    #endregion
    
    #region [생성자]
    public MenuService(
        MenuMapper menuMapper,
        MenuRoleMapper menuRoleMapper,
        UserMapper userMapper,
        UserMenuRoleMapper userMenuRoleMapper
    )
    {
        _menuMapper = menuMapper;
        _menuRoleMapper = menuRoleMapper;
        _userMapper = userMapper;
        _userMenuRoleMapper = userMenuRoleMapper;
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
    /// 메뉴를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<MenuResponseDTO> AddMenu(SaveMenuRequestDTO dto)
    {
        // 1. 메뉴를 추가한다.
        await _menuMapper.AddMenu(dto);

        // 2. 추가한 메뉴 ID를 조회한다.
        var addedMenuId = await _menuMapper.GetMaxMenuId();

        // 3. 메뉴 권한을 추가한다.
        List<AddMenuRoleRequestDTO> addMenuRoleRequestDTOList = [];
        foreach (var roleId in dto.MenuRoles!)
        {
            addMenuRoleRequestDTOList.Add(new AddMenuRoleRequestDTO
            {
                MenuId = addedMenuId,
                RoleId = roleId,
                CreaterId = dto.CreaterId
            });
        }
        await _menuRoleMapper.AddMenuRole(addMenuRoleRequestDTOList);

        // 4. 추가한 메뉴별 사용자 목록을 조회한다.
        List<AddUserMenuRoleRequestDTO> addUserMenuRoleRequestDTOList = [];

        var userList = await _userMapper.ListUserByMenu(addedMenuId);
        foreach (var user in userList)
        {
            addUserMenuRoleRequestDTOList.Add(new AddUserMenuRoleRequestDTO
            {
                MenuId = addedMenuId,
                UserId = user.UserId,
                RoleId = user.RoleId,
                CreaterId = dto.CreaterId
            });
        }
        // 5. 사용자 메뉴 권한을 추가한다.
        await _userMenuRoleMapper.AddUserMenuRole(addUserMenuRoleRequestDTOList);
        
        // 6. 추가한 메뉴를 조회해서 반환한다.
        return await _menuMapper.GetMenu(addedMenuId);
    }

    /// <summary>
    /// 메뉴를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveMenu(int menuId, int? updaterId)
        => await _menuMapper.RemoveMenu(menuId, updaterId);
    #endregion
    
}

