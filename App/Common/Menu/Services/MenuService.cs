using System.Security.Claims;
using SmartSql.AOP;
using svc.App.Common.Auth.Services;
using svc.App.Common.Menu.Models.DTO;
using svc.App.Common.Menu.Repositories;
using svc.App.Shared.Utils;

namespace svc.App.Common.Menu.Services;

/// <summary>
/// 메뉴 서비스 클래스
/// </summary>
public class MenuService
{
    #region Fields
    private readonly AuthService _authService;
    private readonly IMenuRepository _menuRepository;
    #endregion
    
    #region Constructor
    public MenuService(
        AuthService authService,
        IMenuRepository menuRepository
    )
    {
        _authService = authService;
        _menuRepository = menuRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<MenuResponseDTO>> ListMenu(GetMenuRequestDTO getMenuRequestDTO)
    {
        var user = _authService.GetAuthenticatedUser();
        getMenuRequestDTO.UserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        return await _menuRepository.ListMenu(getMenuRequestDTO);
    }
    #endregion
    
}

