using SmartSql;
using svc.App.Menu.Models.DTO;

namespace svc.App.Menu.Repositories;

/// <summary>
/// 메뉴 권한 리포지토리 클래스
/// </summary>
public class MenuRoleRepository : IMenuRoleRepository
{
    public ISqlMapper SqlMapper { get; }

    public MenuRoleRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }

    /// <summary>
    /// 메뉴 권한 목록을 조회한다.
    /// </summary>
    public Task<IList<MenuRoleResponseDTO>> ListMenuRole(GetMenuRoleRequestDTO getMenuRoleRequestDTO)
    {
        return SqlMapper.QueryAsync<MenuRoleResponseDTO>(new RequestContext
        {
            Scope = nameof(MenuRepository),
            SqlId = "ListMenuRole",
            Request = getMenuRoleRequestDTO
        });
    }

}
