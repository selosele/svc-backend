using Svc.App.Common.Menu.Models.DTO;

namespace Svc.App.Common.Menu.Mappers;

/// <summary>
/// 메뉴 권한 매퍼 인터페이스
/// </summary>
public interface IMenuRoleMapper
{
    #region Methods
    /// <summary>
    /// 메뉴 권한 목록을 조회한다.
    /// </summary>
    Task<IList<MenuRoleResponseDTO>> ListMenuRole(GetMenuRoleRequestDTO dto);
    #endregion

}
