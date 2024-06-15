using Dapper;
using svc.App.Auth.Models.DTO;
using svc.App.Auth.Models.Entities;
using svc.App.User.Repositories;
using svc.App.Shared.Configs.Database;

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
        var userRole = await conn.QueryAsync<UserRoleEntity>(UserRoleRepositorySQL.ListUserRole(), getUserRoleRequestDTO);
        return userRole.ToList();
    }

    /// <summary>
    /// 사용자 권한을 추가한다.
    /// </summary>
    public async Task<int> AddUserRole(AddUserRoleRequestDTO addUserRoleRequestDTO)
    {
        using var conn = _connectionProvider.CreateConnection();
        var addResult = await conn.ExecuteAsync(UserRoleRepositorySQL.AddUserRole(), addUserRoleRequestDTO);
        return addResult;
    }

}
