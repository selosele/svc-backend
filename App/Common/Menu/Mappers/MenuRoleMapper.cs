using SmartSql;
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
    public Task<IList<MenuRoleResponseDTO>> ListMenuRole(GetMenuRoleRequestDTO dto)
    {
        return SqlMapper.QueryAsync<MenuRoleResponseDTO>(new RequestContext
        {
            Scope = nameof(MenuRoleMapper),
            SqlId = "ListMenuRole",
            Request = dto
        });
    }

    /// <summary>
    /// 메뉴 권한을 추가한다.
    /// </summary>
    public Task<int> AddMenuRole(List<AddMenuRoleRequestDTO> dtoList)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(MenuRoleMapper),
            SqlId = "AddMenuRole",
            Request = new { DTOList = dtoList }
        });
    }

    /// <summary>
    /// 메뉴 권한을 삭제한다.
    /// </summary>
    public Task<int> RemoveMenuRole(int? menuId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(MenuRoleMapper),
            SqlId = "RemoveMenuRole",
            Request = new { menuId }
        });
    }
    #endregion

}
