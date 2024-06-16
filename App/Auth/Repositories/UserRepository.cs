using Dapper;
using svc.App.Shared.Configs.Database;
using svc.App.Auth.Models.DTO;
using svc.App.Auth.Models.Entities;
using svc.App.Shared.Utils;

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
        var query = new QueryBuilderUtil()
            .Add($@"
                SELECT
                    USER_ID,
                    USER_ACCOUNT,
                    USER_PASSWORD,
                    USER_NAME
                FROM CO_USER
                WHERE USER_ACCOUNT = @UserAccount
            ")
            .Build();
        var user = await conn.QuerySingleOrDefaultAsync<UserEntity>(query, getUserRequestDTO);
        return user;
    }

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    public async Task<UserEntity?> AddUser(AddUserRequestDTO addUserRequestDTO)
    {
        using var conn = _connectionProvider.CreateConnection();
        var command = new QueryBuilderUtil()
            .Add($@"
                INSERT INTO CO_USER (USER_ACCOUNT, USER_PASSWORD, USER_NAME, CREATER_ID)
                VALUES (@UserAccount, @UserPassword, @UserName, @CreaterId)
            ")
            .Build();
        await conn.ExecuteAsync(command, addUserRequestDTO);

        var query = new QueryBuilderUtil()
            .Add($@"
                SELECT
                    USER_ID,
                    USER_ACCOUNT,
                    USER_PASSWORD,
                    USER_NAME
                FROM CO_USER
                WHERE USER_ACCOUNT = @UserAccount
            ")
            .Build();
        var user = await conn.QuerySingleOrDefaultAsync<UserEntity>(query, addUserRequestDTO);
        return user;
    }

}
