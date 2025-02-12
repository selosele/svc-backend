using SmartSql;
using Svc.App.Shared.Extensions;
using Svc.App.Common.Menu.Models.DTO;

namespace Svc.App.Common.Menu.Mappers;

/// <summary>
/// 메뉴 권한 매퍼 클래스
/// </summary>
public class MenuRoleMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public MenuRoleMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 메뉴 권한 목록을 조회한다.
    /// </summary>
    public Task<IList<MenuRoleResultDTO>> ListMenuRole(GetMenuRoleRequestDTO dto)
        => SqlMapper.QueryForList<MenuRoleResultDTO>($"{nameof(MenuRoleMapper)}.ListMenuRole", dto);

    /// <summary>
    /// 메뉴 권한을 추가한다.
    /// </summary>
    public Task<int> AddMenuRole(List<AddMenuRoleRequestDTO> dtoList)
        => SqlMapper.Execute($"{nameof(MenuRoleMapper)}.AddMenuRole", new { DTOList = dtoList });

    /// <summary>
    /// 메뉴 권한을 삭제한다.
    /// </summary>
    public Task<int> RemoveMenuRole(int? menuId)
        => SqlMapper.Execute($"{nameof(MenuRoleMapper)}.RemoveMenuRole", new { menuId });
    #endregion

}
