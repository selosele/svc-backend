using Dapper;
using svc.App.Menu.Models.DTO;
using svc.App.Menu.Models.Entities;
using svc.App.Shared.Configs.Database;
using svc.App.Shared.Utils;

namespace svc.App.Menu.Repositories;

/// <summary>
/// 메뉴 권한 리포지토리 클래스
/// </summary>
public class MenuRoleRepository
{
    private readonly ConnectionProvider _connectionProvider;
    public MenuRoleRepository(ConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    /// <summary>
    /// 메뉴 권한 목록을 조회한다.
    /// </summary>
    public async Task<List<MenuRoleEntity>> ListMenuRole(GetMenuRoleRequestDTO getMenuRoleRequestDTO)
    {
        using var conn = _connectionProvider.CreateConnection();
        var query = new QueryBuilderUtil()
            .Add($@"
                SELECT
                    MENU_ID,
                    ROLE_ID
                FROM CO_MENU_ROLE
                WHERE ROLE_ID IN (
                    SELECT
                        ROLE_ID
                    FROM CO_USER_ROLE
                    WHERE USER_ID = @UserId
                )
                "
            )
            .Build();
        var menuRole = await conn.QueryAsync<MenuRoleEntity>(query, getMenuRoleRequestDTO);
        return menuRole.ToList();
    }

}
