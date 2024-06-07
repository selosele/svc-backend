using Dapper;
using svc.App.Shared.Configs.Database;
using svc.App.Auth.Models.DTO;
using svc.App.Auth.Models.Entities;
using svc.App.User.Repositories;

namespace svc.App.Auth.Repositories;

public class UserRepository
{
    private readonly ConnectionProvider _connectionProvider;
    public UserRepository(ConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    public async Task<UserEntity?> GetUser(SignInRequestDTO signInRequestDTO)
    {
        using var conn = _connectionProvider.CreateConnection();
        var result = await conn.QuerySingleOrDefaultAsync<UserEntity>(
            UserRepositorySQL.GetUser(),
            new SignInRequestDTO { UserAccount = signInRequestDTO.UserAccount }
        );
        return result;
    }

}
