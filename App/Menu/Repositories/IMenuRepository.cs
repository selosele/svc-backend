using svc.App.Menu.Models.DTO;

namespace svc.App.Menu.Repositories;

/// <summary>
/// 메뉴 리포지토리 인터페이스
/// </summary>
public interface IMenuRepository
{
    #region Methods
    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    Task<IList<MenuResponseDTO>> ListMenu(GetMenuRequestDTO getMenuRequestDTO);
    #endregion

}
