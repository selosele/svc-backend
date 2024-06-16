using Dapper;
using svc.App.Code.Models.Entities;
using svc.App.Shared.Configs.Database;
using svc.App.Shared.Utils;

namespace svc.App.Code.Repositories;

/// <summary>
/// 코드 리포지토리 클래스
/// </summary>
public class CodeRepository
{
    private readonly ConnectionProvider _connectionProvider;
    public CodeRepository(ConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    public async Task<List<CodeEntity>> ListCode()
    {
        using var conn = _connectionProvider.CreateConnection();
        var query = new QueryBuilderUtil()
            .Add($@"
                WITH RECURSIVE R AS (
                    SELECT
                        CODE_ID,
                        UP_CODE_ID,
                        CODE_VALUE,
                        CODE_NAME,
                        CODE_CONTENT,
                        CODE_ORDER,
                        CAST(CODE_ORDER AS CHAR(200)) AS SORT_ORDER,
                        CODE_USE_YN,
                        CODE_DELETE_YN
                    FROM CO_CODE
                    WHERE UP_CODE_ID IS NULL
                    UNION ALL
                    SELECT
                        A.CODE_ID,
                        A.UP_CODE_ID,
                        A.CODE_VALUE,
                        A.CODE_NAME,
                        A.CODE_CONTENT,
                        A.CODE_ORDER,
                        CONCAT(R.SORT_ORDER, '-', LPAD(A.CODE_ORDER, 5, '0')) AS SORT_ORDER,
                        A.CODE_USE_YN,
                        A.CODE_DELETE_YN
                    FROM CO_CODE A
                    INNER JOIN R ON A.UP_CODE_ID = R.CODE_ID
                )
                SELECT
                    R.CODE_ID,
                    R.UP_CODE_ID,
                    R.CODE_VALUE,
                    R.CODE_NAME,
                    R.CODE_CONTENT,
                    R.CODE_ORDER,
                    R.CODE_USE_YN,
                    R.CODE_DELETE_YN
                FROM R
                ORDER BY
                    CAST(SUBSTRING_INDEX(R.SORT_ORDER, '-', 1) AS UNSIGNED),
                    CASE
                        WHEN R.SORT_ORDER LIKE '%-%' THEN CAST(SUBSTRING_INDEX(R.SORT_ORDER, '-', -1) AS UNSIGNED)
                        ELSE 0
                    END
        ")
        .Build();
        var code = await conn.QueryAsync<CodeEntity>(query);
        return code.ToList();
    }

}
