using MySqlConnector;

namespace svc.App.Shared.Configs.Database;

/// <summary>
/// DB 커넥션을 관리하는 클래스
/// </summary>
public class ConnectionProvider
{
    private readonly IConfiguration _configuration;

    public ConnectionProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// DB 커넥션을 생성해서 반환한다.
    /// </summary>
    public MySqlConnection CreateConnection()
    {
        var conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        conn.Open();
        return conn;
    }

}