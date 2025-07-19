using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Common.Menu.Models.DTO;

namespace Svc.App.Common.Menu.Mappers;

/// <summary>
/// 메뉴 권한 매퍼
/// </summary>
public class MenuRoleMapper(ISqlMapper sqlMapper) : MyMapperBase(sqlMapper)
{
    #region [메서드]
    /// <summary>
    /// 메뉴 권한 목록을 조회한다.
    /// </summary>
    public Task<IList<MenuRoleResultDTO>> ListMenuRole(GetMenuRoleRequestDTO dto)
        => QueryForList<MenuRoleResultDTO>($"{nameof(MenuRoleMapper)}.ListMenuRole", dto);

    /// <summary>
    /// 메뉴 권한을 추가한다.
    /// </summary>
    public Task<int> AddMenuRole(List<AddMenuRoleRequestDTO> dtoList)
        => Execute($"{nameof(MenuRoleMapper)}.AddMenuRole", new { DTOList = dtoList });

    /// <summary>
    /// 메뉴 권한을 삭제한다.
    /// </summary>
    public Task<int> RemoveMenuRole(int? menuId)
        => Execute($"{nameof(MenuRoleMapper)}.RemoveMenuRole", new { menuId });
    #endregion

}
