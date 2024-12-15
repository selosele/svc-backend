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
    #endregion
    
    #region [생성자]
    public MenuService(
        MenuMapper menuMapper
    )
    {
        _menuMapper = menuMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<MenuResponseDTO>> ListMenu(GetMenuRequestDTO dto)
        => await _menuMapper.ListMenu(dto);
    #endregion
    
}

