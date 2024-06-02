using System.Data;
using Dapper;
using svc.Configs.DataBase;
using svc.Models.Entities.Code;

namespace svc.Repositories.Code;

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
