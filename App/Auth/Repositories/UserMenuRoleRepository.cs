using SmartSql;
using svc.App.Auth.Models.DTO;

namespace svc.App.Auth.Repositories;

/// <summary>
/// 사용자 메뉴 권한 리포지토리 클래스
/// </summary>
public class UserMenuRoleRepository : IUserMenuRoleRepository
{
    public ISqlMapper SqlMapper { get; }

    public UserMenuRoleRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }

    /// <summary>
    /// 사용자 메뉴 권한을 추가한다.
    /// </summary>
    public Task<int> AddUserMenuRole(AddUserMenuRoleRequestDTO addUserMenuRoleRequestDTO)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserMenuRoleRepository),
            SqlId = "AddUserMenuRole",
            Request = addUserMenuRoleRequestDTO
        });
    }

}
