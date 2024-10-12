using Svc.App.Common.Menu.Models.DTO;

namespace Svc.App.Common.Menu.Mappers;

/// <summary>
/// 메뉴 매퍼 인터페이스
/// </summary>
public interface IMenuMapper
{
    #region Methods
    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    Task<IList<MenuResponseDTO>> ListMenu(GetMenuRequestDTO dto);
    #endregion

}
