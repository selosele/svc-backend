using svc.App.Menu.Models.DTO;
using svc.App.Menu.Models.Entities;

namespace svc.App.Menu.Repositories;

/// <summary>
/// 메뉴 권한 리포지토리 인터페이스
/// </summary>
public interface IMenuRoleRepository
{
    /// <summary>
    /// 메뉴 권한 목록을 조회한다.
    /// </summary>
    Task<IList<MenuRoleEntity>> ListMenuRole(GetMenuRoleRequestDTO getMenuRoleRequestDTO);

}
