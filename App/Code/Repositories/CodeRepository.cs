using System.Data;
using Dapper;
using svc.App.Code.Models.Entities;
using svc.App.Configs.Database;

namespace svc.App.Code.Repositories;

public class CodeRepository : ICodeRepository
{
    public IConnectionProvider _connectionProvider;
    public IDbConnection _conn;
    public CodeRepository(IConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
        _conn = _connectionProvider.CreateConnection();
    }

    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    public async Task<List<CodeEntity>> ListCode()
    {
        try
        {
            _conn.Open();
            var result = await _conn.QueryAsync<CodeEntity>(CodeRepositorySQL.ListCode());
            return result.ToList();
        }
        catch (Exception)
        {
            return [];
        }
        finally
        {
            _conn.Close();
        }
    }
}
