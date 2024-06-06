using System.Data;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace svc.App.Configs.Database;

public interface IConnectionProvider {
    IDbConnection CreateConnection();
}

public class ConnectionProvider : IConnectionProvider
{
    private readonly IDbConnection _dbConnection;

    public ConnectionProvider(IOptions<ConnectionString> connectionString)
    {
        _dbConnection = new MySqlConnection(connectionString.Value.DefaultConnection);
    }

    public IDbConnection CreateConnection()
        => _dbConnection;
}