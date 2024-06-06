using Microsoft.Extensions.Options;
using MySqlConnector;

namespace svc.App.Shared.Configs.Database;

/// <summary>
/// DB 커넥션을 관리하는 클래스
/// </summary>
public class ConnectionProvider
{
    private readonly MySqlConnection _dbConnection;

    public ConnectionProvider(IOptions<ConnectionString> connectionString)
    {
        _dbConnection = new MySqlConnection(connectionString.Value.DefaultConnection);
    }

    /// <summary>
    /// DB 커넥션을 생성해서 반환한다.
    /// </summary>
    public MySqlConnection CreateConnection()
    {
        _dbConnection.Open();
        return _dbConnection;
    }
        
}