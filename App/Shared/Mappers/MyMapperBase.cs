using SmartSql;

namespace Svc.App.Shared.Mappers;

/// <summary>
/// 매퍼의 기본 클래스
/// </summary>
public class MyMapperBase(ISqlMapper sqlMapper)
{
    #region [필드]
    private ISqlMapper SqlMapper { get; } = sqlMapper;
    #endregion

    #region [메서드]
    /// <summary>
    /// 다건 조회를 수행한다.
    /// </summary>
    public Task<IList<T>> QueryForList<T>(string sqlId, object? request = null)
    {
        return SqlMapper.QueryAsync<T>(new RequestContext
        {
            Scope = sqlId.Split(".")[0],
            SqlId = sqlId.Split(".")[1],
            Request = request
        });
    }

    /// <summary>
    /// 단건 조회를 수행한다.
    /// </summary>
    public Task<T> QueryForObject<T>(string sqlId, object? request = null)
    {
        return SqlMapper.QuerySingleAsync<T>(new RequestContext
        {
            Scope = sqlId.Split(".")[0],
            SqlId = sqlId.Split(".")[1],
            Request = request
        });
    }

    /// <summary>
    /// INSERT, UPDATE, DELETE를 수행하고 row count를 반환한다.
    /// </summary>
    public Task<int> Execute(string sqlId, object? request = null)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = sqlId.Split(".")[0],
            SqlId = sqlId.Split(".")[1],
            Request = request
        });
    }

    /// <summary>
    /// INSERT, UPDATE, DELETE를 수행하고 쿼리 실행 결과를 반환한다.
    /// </summary>
    public Task<T> ExecuteScalar<T>(string sqlId, object? request = null)
    {
        return SqlMapper.ExecuteScalarAsync<T>(new RequestContext
        {
            Scope = sqlId.Split(".")[0],
            SqlId = sqlId.Split(".")[1],
            Request = request
        });
    }
    #endregion
}