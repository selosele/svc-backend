using Dapper;
using svc.App.Shared.Configs.Database;
using svc.App.Auth.Models.DTO;
using svc.App.Auth.Models.Entities;
using svc.App.User.Repositories;

namespace svc.App.Auth.Repositories;

/// <summary>
/// 사용자 리포지토리 클래스
/// </summary>
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
    public async Task<UserEntity?> GetUser(GetUserRequestDTO getUserRequestDTO)
    {
        using var conn = _connectionProvider.CreateConnection();
        var user = await conn.QuerySingleOrDefaultAsync<UserEntity>(UserRepositorySQL.GetUser(), getUserRequestDTO);
        return user;
    }

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    public async Task<UserEntity?> AddUser(AddUserRequestDTO addUserRequestDTO)
    {
        using var conn = _connectionProvider.CreateConnection();
        await conn.ExecuteAsync(UserRepositorySQL.AddUser(), addUserRequestDTO);
        var user = await conn.QuerySingleOrDefaultAsync<UserEntity>(UserRepositorySQL.GetUser(), addUserRequestDTO);
        return user;
    }

}
