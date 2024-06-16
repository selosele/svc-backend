using svc.App.Menu.Models.DTO;
using svc.App.Menu.Models.Entities;
using svc.App.Menu.Repositories;

namespace svc.App.Menu.Services;

/// <summary>
/// 메뉴 서비스 클래스
/// </summary>
public class MenuService
{
    private readonly MenuRepository _menuRepository;
    public MenuService(MenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    public async Task<List<MenuEntity>> ListMenu(GetMenuRequestDTO getMenuRequestDTO)
    {
        return await _menuRepository.ListMenu(getMenuRequestDTO);
    }
    
}

