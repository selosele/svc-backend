using Dapper;
using MySqlConnector;
using svc.App.Shared.Configs.Database;
using svc.App.Auth.Models.DTO;
using svc.App.Auth.Models.Entities;
using svc.App.User.Repositories;

namespace svc.App.Auth.Repositories;

public class UserRepository
{
    private readonly ConnectionProvider _connectionProvider;
    private readonly MySqlConnection _conn;
    public UserRepository(ConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
        _conn = _connectionProvider.CreateConnection();
    }

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    public async Task<UserEntity?> GetUser(SignInRequestDTO signInRequestDTO)
    {
        var result = await _conn.QuerySingleOrDefaultAsync<UserEntity>(
            UserRepositorySQL.GetUser(),
            new SignInRequestDTO { UserAccount = signInRequestDTO.UserAccount }
        );
        _conn.Close();
        return result;
    }

}
