using System.Data;
using Dapper;
using svc.App.Code.Models.Entities;
using svc.App.Configs.Database;

namespace svc.App.Code.Repositories;

public class CodeRepository
{
    public ConnectionProvider _connectionProvider;
    public IDbConnection _conn;
    public CodeRepository(ConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
        _conn = _connectionProvider.CreateConnection();
    }

    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    public async Task<List<CodeEntity>> ListCode()
    {
        var result = await _conn.QueryAsync<CodeEntity>(CodeRepositorySQL.ListCode());
        _conn.Close();
        return result.ToList();
    }

}
