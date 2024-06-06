namespace svc.App.Code.Repositories;

public class CodeRepositorySQL
{
    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    public static string ListCode()
    {
        return $@"
            WITH RECURSIVE R AS (
                SELECT
                    CODE_ID,
                    UP_CODE_ID,
                    CODE_VALUE,
                    CODE_NAME,
                    CODE_CONTENT,
                    CODE_ORDER,
                    CAST(CODE_ORDER AS CHAR(200)) AS SORT_ORDER,
                    CODE_USE_AT,
                    CODE_DELETE_AT
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
                    A.CODE_USE_AT,
                    A.CODE_DELETE_AT
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
                R.CODE_USE_AT,
                R.CODE_DELETE_AT
            FROM R
            ORDER BY
                CAST(SUBSTRING_INDEX(R.SORT_ORDER, '-', 1) AS UNSIGNED),
                CASE
                    WHEN R.SORT_ORDER LIKE '%-%' THEN CAST(SUBSTRING_INDEX(R.SORT_ORDER, '-', -1) AS UNSIGNED)
                    ELSE 0
                END
        ";
    }
    
}
