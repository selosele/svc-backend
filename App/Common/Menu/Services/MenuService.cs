using SmartSql.AOP;
using Svc.App.Common.Menu.Models.DTO;
using Svc.App.Common.Menu.Mappers;

namespace Svc.App.Common.Menu.Services;

/// <summary>
/// 메뉴 서비스 클래스
/// </summary>
public class MenuService
{
    #region Fields
    private readonly MenuMapper _menuMapper;
    #endregion
    
    #region Constructor
    public MenuService(
        MenuMapper menuMapper
    )
    {
        _menuMapper = menuMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<MenuResponseDTO>> ListMenu(GetMenuRequestDTO dto)
        => await _menuMapper.ListMenu(dto);
    #endregion
    
}

