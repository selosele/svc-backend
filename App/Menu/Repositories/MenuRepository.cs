using Dapper;
using svc.App.Menu.Models.DTO;
using svc.App.Menu.Models.Entities;
using svc.App.Shared.Configs.Database;
using svc.App.Shared.Utils;

namespace svc.App.Menu.Repositories;

/// <summary>
/// 메뉴 리포지토리 클래스
/// </summary>
public class MenuRepository
{
    private readonly ConnectionProvider _connectionProvider;
    
    public MenuRepository(ConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    public async Task<List<MenuEntity>> ListMenu(GetMenuRequestDTO getMenuRequestDTO)
    {
        using var conn = _connectionProvider.CreateConnection();
        var query = new QueryBuilderUtil()
            .Add($@"
                WITH RECURSIVE R AS (
                    SELECT
                        MENU_ID,
                        UP_MENU_ID,
                        MENU_NAME,
                        MENU_URL,
                        MENU_ORDER,
                        MENU_DEPTH,
                        CAST(MENU_ORDER AS CHAR(200)) AS SORT_ORDER,
                        MENU_SHOW_YN,
                        MENU_USE_YN,
                        MENU_DELETE_YN
                    FROM CO_MENU
                    WHERE UP_MENU_ID IS NULL
                    UNION ALL
                    SELECT
                        A.MENU_ID,
                        A.UP_MENU_ID,
                        A.MENU_NAME,
                        A.MENU_URL,
                        A.MENU_ORDER,
                        A.MENU_DEPTH,
                        CONCAT(R.SORT_ORDER, '-', LPAD(A.MENU_ORDER, 5, '0')) AS SORT_ORDER,
                        A.MENU_SHOW_YN,
                        A.MENU_USE_YN,
                        A.MENU_DELETE_YN
                    FROM CO_MENU A
                    INNER JOIN R ON A.UP_MENU_ID = R.MENU_ID
                )
                SELECT
                    R.MENU_ID,
                    R.UP_MENU_ID,
                    R.MENU_NAME,
                    R.MENU_URL,
                    R.MENU_ORDER,
                    R.MENU_DEPTH,
                    R.MENU_SHOW_YN,
                    R.MENU_USE_YN,
                    R.MENU_DELETE_YN
                FROM R
                WHERE R.MENU_ID IN (
                    SELECT
                        MR.MENU_ID
                    FROM CO_MENU_ROLE MR
                    INNER JOIN CO_USER_MENU_ROLE UMR ON MR.MENU_ID = UMR.MENU_ID AND MR.ROLE_ID = UMR.ROLE_ID
                    WHERE UMR.USER_ID = @UserId
                )
                "
            )
            .Add("AND R.MENU_SHOW_YN   = @MenuShowYn",   !string.IsNullOrWhiteSpace(getMenuRequestDTO.MenuShowYn))
            .Add("AND R.MENU_USE_YN    = @MenuUseYn",    !string.IsNullOrWhiteSpace(getMenuRequestDTO.MenuUseYn))
            .Add("AND R.MENU_DELETE_YN = @MenuDeleteYn", !string.IsNullOrWhiteSpace(getMenuRequestDTO.MenuDeleteYn))
            .Add($@"
                ORDER BY
                    CAST(SUBSTRING_INDEX(R.SORT_ORDER, '-', 1) AS UNSIGNED),
                    CASE
                        WHEN R.SORT_ORDER LIKE '%-%' THEN CAST(SUBSTRING_INDEX(R.SORT_ORDER, '-', -1) AS UNSIGNED)
                        ELSE 0
                    END
                "
            )
            .Build();
        var menu = await conn.QueryAsync<MenuEntity>(query, getMenuRequestDTO);
        return menu.ToList();
    }

}
