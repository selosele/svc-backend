using System.Security.Claims;
using svc.App.Auth.Services;
using svc.App.Menu.Models.DTO;
using svc.App.Menu.Models.Entities;
using svc.App.Menu.Repositories;
using svc.App.Shared.Utils;

namespace svc.App.Menu.Services;

/// <summary>
/// 메뉴 서비스 클래스
/// </summary>
public class MenuService
{
    private readonly AuthService _authService;
    private readonly MenuRepository _menuRepository;
    
    public MenuService(
        AuthService authService,
        MenuRepository menuRepository
    )
    {
        _authService = authService;
        _menuRepository = menuRepository;
    }

    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    public async Task<List<MenuEntity>> ListMenu(GetMenuRequestDTO getMenuRequestDTO)
    {
        var user = _authService.GetAuthenticatedUser();
        getMenuRequestDTO.UserId = int.Parse(user?.FindFirstValue(ClaimUtil.IdIdentifier)!);
        return await _menuRepository.ListMenu(getMenuRequestDTO);
    }
    
}

