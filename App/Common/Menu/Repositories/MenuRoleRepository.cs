using SmartSql;
using Svc.App.Common.Menu.Models.DTO;

namespace Svc.App.Common.Menu.Repositories;

/// <summary>
/// 메뉴 권한 리포지토리 클래스
/// </summary>
public class MenuRoleRepository : IMenuRoleRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public MenuRoleRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 메뉴 권한 목록을 조회한다.
    /// </summary>
    public Task<IList<MenuRoleResponseDTO>> ListMenuRole(GetMenuRoleRequestDTO getMenuRoleRequestDTO)
    {
        return SqlMapper.QueryAsync<MenuRoleResponseDTO>(new RequestContext
        {
            Scope = nameof(MenuRoleRepository),
            SqlId = "ListMenuRole",
            Request = getMenuRoleRequestDTO
        });
    }
    #endregion

}
