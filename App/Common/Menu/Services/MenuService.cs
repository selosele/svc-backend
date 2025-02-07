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
    private readonly MenuBookmarkMapper _menuBookmarkMapper;
    private readonly UserMapper _userMapper;
    private readonly UserMenuRoleMapper _userMenuRoleMapper;
    #endregion
    
    #region [생성자]
    public MenuService(
        MenuMapper menuMapper,
        MenuRoleMapper menuRoleMapper,
        MenuBookmarkMapper menuBookmarkMapper,
        UserMapper userMapper,
        UserMenuRoleMapper userMenuRoleMapper
    )
    {
        _menuMapper = menuMapper;
        _menuRoleMapper = menuRoleMapper;
        _menuBookmarkMapper = menuBookmarkMapper;
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
        menu.MenuRoleList = await _menuRoleMapper.ListMenuRole(new GetMenuRoleRequestDTO { MenuId = menuId });
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
        foreach (var roleId in dto.MenuRoleList!)
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
    /// 메뉴를 수정한다.
    /// </summary>
    [Transaction]
    public async Task<MenuResponseDTO> UpdateMenu(SaveMenuRequestDTO dto)
    {
        // 1. 메뉴를 수정한다.
        await _menuMapper.UpdateMenu(dto);

        // 2. 메뉴 권한을 삭제한다.
        await _menuRoleMapper.RemoveMenuRole(dto.MenuId);

        // 3. 메뉴 권한을 추가한다.
        List<AddMenuRoleRequestDTO> addMenuRoleRequestDTOList = [];
        foreach (var roleId in dto.MenuRoleList!)
        {
            addMenuRoleRequestDTOList.Add(new AddMenuRoleRequestDTO
            {
                MenuId = dto.MenuId,
                RoleId = roleId,
                CreaterId = dto.CreaterId
            });
        }
        await _menuRoleMapper.AddMenuRole(addMenuRoleRequestDTOList);

        // 4. 수정한 메뉴별 사용자 목록을 조회한다.
        List<AddUserMenuRoleRequestDTO> addUserMenuRoleRequestDTOList = [];

        var userList = await _userMapper.ListUserByMenu(dto.MenuId);
        foreach (var user in userList)
        {
            addUserMenuRoleRequestDTOList.Add(new AddUserMenuRoleRequestDTO
            {
                MenuId = dto.MenuId,
                UserId = user.UserId,
                RoleId = user.RoleId,
                CreaterId = dto.CreaterId
            });
        }

        // 5. 사용자 메뉴 권한을 삭제한다.
        await _userMenuRoleMapper.RemoveUserMenuRole(new RemoveUserMenuRoleRequestDTO { MenuId = dto.MenuId });

        // 6. 사용자 메뉴 권한을 추가한다.
        await _userMenuRoleMapper.AddUserMenuRole(addUserMenuRoleRequestDTOList);
        
        // 7. 수정한 메뉴를 조회해서 반환한다.
        return await _menuMapper.GetMenu(dto.MenuId);
    }

    /// <summary>
    /// 메뉴를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveMenu(int menuId, int? updaterId)
        => await _menuMapper.RemoveMenu(menuId, updaterId);

    /// <summary>
    /// 메뉴 즐겨찾기 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<MenuBookmarkResultDTO>> ListMenuBookmark(int? userId)
        => await _menuBookmarkMapper.ListMenuBookmark(userId);

    /// <summary>
    /// 메뉴 즐겨찾기를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<MenuBookmarkResultDTO> AddMenuBookmark(SaveMenuBookmarkRequestDTO dto)
    {
        var menuBookmarkId = await _menuBookmarkMapper.AddMenuBookmark(dto);
        return await _menuBookmarkMapper.GetMenuBookmark(menuBookmarkId);
    }

    /// <summary>
    /// 모든 메뉴 즐겨찾기를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveMenuBookmarkAll(int? userId)
        => await _menuBookmarkMapper.RemoveMenuBookmarkAll(userId);

    /// <summary>
    /// 메뉴 즐겨찾기를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveMenuBookmark(int menuBookmarkId)
        => await _menuBookmarkMapper.RemoveMenuBookmark(menuBookmarkId);
    #endregion
    
}

