using System.Security.Claims;
using svc.App.Auth.Services;
using svc.App.Menu.Models.DTO;
using svc.App.Menu.Models.Entities;
using svc.App.Menu.Repositories;
using svc.App.Shared.Utils;
using SmartSql.AOP;

namespace svc.App.Menu.Services;

/// <summary>
/// 메뉴 서비스 클래스
/// </summary>
public class MenuService
{
    private readonly AuthService _authService;
    private readonly IMenuRepository _menuRepository;
    
    public MenuService(
        AuthService authService,
        IMenuRepository menuRepository
    )
    {
        _authService = authService;
        _menuRepository = menuRepository;
    }

    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<MenuEntity>> ListMenu(GetMenuRequestDTO getMenuRequestDTO)
    {
        var user = _authService.GetAuthenticatedUser();
        getMenuRequestDTO.UserId = int.Parse(user?.FindFirstValue(ClaimUtil.IdIdentifier)!);
        return await _menuRepository.ListMenu(getMenuRequestDTO);
    }
    
}

