using Microsoft.Extensions.Options;
using MySqlConnector;

namespace svc.App.Shared.Configs.Database;

public class ConnectionProvider
{
    private readonly MySqlConnection _dbConnection;

    public ConnectionProvider(IOptions<ConnectionString> connectionString)
    {
        _dbConnection = new MySqlConnection(connectionString.Value.DefaultConnection);
    }

    public MySqlConnection CreateConnection()
    {
        _dbConnection.Open();
        return _dbConnection;
    }
        
}