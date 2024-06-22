namespace svc.App.Shared.Utils;

/// <summary>
/// 쿼리빌더 유틸 클래스
/// </summary>
public class QueryBuilderUtil
{
    /// <summary>
    /// 쿼리빌더 SQL
    /// </summary>
    private string _sql = "";

    /// <summary>
    /// 쿼리빌더 SQL을 추가한다.
    /// </summary>
    public QueryBuilderUtil Add(string sql, bool condition = true)
    {
        if (condition)
        {
            _sql += "\n" + sql;
        }
        return this;
    }

    /// <summary>
    /// 쿼리빌더 최종 SQL을 반환한다.
    /// </summary>
    public string Build()
    {
        return _sql;
    }
    
}
