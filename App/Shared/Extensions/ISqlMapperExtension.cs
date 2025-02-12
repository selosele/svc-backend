using SmartSql;

namespace Svc.App.Shared.Extensions;

/// <summary>
/// ISqlMapper의 확장 메서드를 제공하는 클래스
/// </summary>
public static class ISqlMapperExtension
{
    #region [메서드]
    /// <summary>
    /// 다건 조회를 수행한다.
    /// </summary>
    public static Task<IList<T>> QueryForList<T>(this ISqlMapper sqlMapper, string mapperName, string sqlId, object? request = null)
    {
        return sqlMapper.QueryAsync<T>(new RequestContext
        {
            Scope = mapperName,
            SqlId = sqlId,
            Request = request
        });
    }

    /// <summary>
    /// 단건 조회를 수행한다.
    /// </summary>
    public static Task<T> QueryForObject<T>(this ISqlMapper sqlMapper, string mapperName, string sqlId, object? request = null)
    {
        return sqlMapper.QuerySingleAsync<T>(new RequestContext
        {
            Scope = mapperName,
            SqlId = sqlId,
            Request = request
        });
    }

    /// <summary>
    /// INSERT, UPDATE, DELETE를 수행하고 row count를 반환한다.
    /// </summary>
    public static Task<int> Execute(this ISqlMapper sqlMapper, string mapperName, string sqlId, object? request = null)
    {
        return sqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = mapperName,
            SqlId = sqlId,
            Request = request
        });
    }

    /// <summary>
    /// INSERT, UPDATE, DELETE를 수행하고 쿼리 실행 결과를 반환한다.
    /// </summary>
    public static Task<T> ExecuteScalar<T>(this ISqlMapper sqlMapper, string mapperName, string sqlId, object? request = null)
    {
        return sqlMapper.ExecuteScalarAsync<T>(new RequestContext
        {
            Scope = mapperName,
            SqlId = sqlId,
            Request = request
        });
    }
    #endregion

}