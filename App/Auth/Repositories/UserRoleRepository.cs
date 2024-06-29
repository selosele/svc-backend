using SmartSql;
using svc.App.Auth.Models.DTO;
using svc.App.Auth.Models.Entities;

namespace svc.App.Auth.Repositories;

/// <summary>
/// 사용자 권한 리포지토리 클래스
/// </summary>
public class UserRoleRepository : IUserRoleRepository
{
    public ISqlMapper SqlMapper { get; }

    public UserRoleRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }

    /// <summary>
    /// 사용자 권한 목록을 조회한다.
    /// </summary>
    public Task<IList<UserRoleEntity>> ListUserRole(GetUserRoleRequestDTO getUserRoleRequestDTO)
    {
        return SqlMapper.QueryAsync<UserRoleEntity>(new RequestContext
        {
            Scope = nameof(UserRoleRepository),
            SqlId = "ListUserRole",
            Request = getUserRoleRequestDTO
        });
    }

    /// <summary>
    /// 사용자 권한을 추가한다.
    /// </summary>
    public Task<int> AddUserRole(AddUserRoleRequestDTO addUserRoleRequestDTO)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserRoleRepository),
            SqlId = "AddUserRole",
            Request = addUserRoleRequestDTO
        });
    }

}
