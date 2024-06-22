using Dapper;
using svc.App.Auth.Models.DTO;
using svc.App.Shared.Configs.Database;
using svc.App.Shared.Utils;

namespace svc.App.Auth.Repositories;

/// <summary>
/// 사용자 메뉴 권한 리포지토리 클래스
/// </summary>
public class UserMenuRoleRepository
{
    private readonly ConnectionProvider _connectionProvider;
    public UserMenuRoleRepository(ConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    /// <summary>
    /// 사용자 메뉴 권한을 추가한다.
    /// </summary>
    public async Task<int> AddUserMenuRole(AddUserMenuRoleRequestDTO addUserMenuRoleRequestDTO)
    {
        using var conn = _connectionProvider.CreateConnection();
        var command = new QueryBuilderUtil()
            .Add($@"
                INSERT INTO CO_USER_MENU_ROLE (USER_ID, MENU_ID, ROLE_ID, CREATER_ID)
                VALUES (@UserId, @MenuId, @RoleId, @CreaterId)
            ")
            .Build();
        var addResult = await conn.ExecuteAsync(command, addUserMenuRoleRequestDTO);
        return addResult;
    }

}
