using SmartSql;
using Svc.App.Common.Menu.Models.DTO;

namespace Svc.App.Common.Menu.Mappers;

/// <summary>
/// 메뉴 권한 매퍼 클래스
/// </summary>
public class MenuRoleMapper : IMenuRoleMapper
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public MenuRoleMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
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
    #endregion

}
