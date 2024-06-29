using svc.App.Menu.Models.DTO;
using svc.App.Menu.Models.Entities;

namespace svc.App.Menu.Repositories;

/// <summary>
/// 메뉴 리포지토리 인터페이스
/// </summary>
public interface IMenuRepository
{
    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    Task<IList<MenuEntity>> ListMenu(GetMenuRequestDTO getMenuRequestDTO);

}
