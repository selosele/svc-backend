using Dapper;
using svc.App.Code.Models.Entities;
using svc.App.Shared.Configs.Database;

namespace svc.App.Code.Repositories;

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
        var result = await conn.QueryAsync<CodeEntity>(CodeRepositorySQL.ListCode());
        return result.ToList();
    }

}
