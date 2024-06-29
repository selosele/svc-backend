using Dapper;
using svc.App.Auth.Models.DTO;
using svc.App.Auth.Models.Entities;
using svc.App.Shared.Configs.Database;
using svc.App.Shared.Utils;

namespace svc.App.Auth.Repositories;

/// <summary>
/// 사용자 권한 리포지토리 클래스
/// </summary>
public class UserRoleRepository
{
    private readonly ConnectionProvider _connectionProvider;
    
    public UserRoleRepository(ConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    /// <summary>
    /// 사용자 권한 목록을 조회한다.
    /// </summary>
    public async Task<List<UserRoleEntity>> ListUserRole(GetUserRoleRequestDTO getUserRoleRequestDTO)
    {
        using var conn = _connectionProvider.CreateConnection();
        var query = new QueryBuilderUtil()
            .Add($@"
                SELECT
                    UR.USER_ID,
                    UR.ROLE_ID
                FROM CO_USER_ROLE UR
                INNER JOIN CO_USER U ON U.USER_ID = UR.USER_ID
                WHERE U.USER_ID = @UserId
            ")
            .Build();
        var userRole = await conn.QueryAsync<UserRoleEntity>(query, getUserRoleRequestDTO);
        return userRole.ToList();
    }

    /// <summary>
    /// 사용자 권한을 추가한다.
    /// </summary>
    public async Task<int> AddUserRole(AddUserRoleRequestDTO addUserRoleRequestDTO)
    {
        using var conn = _connectionProvider.CreateConnection();
        var command = new QueryBuilderUtil()
            .Add($@"
                INSERT INTO CO_USER_ROLE (USER_ID, ROLE_ID, CREATER_ID)
                VALUES (@UserId, @RoleId, @CreaterId)
            ")
            .Build();
        var addResult = await conn.ExecuteAsync(command, addUserRoleRequestDTO);
        return addResult;
    }

}
