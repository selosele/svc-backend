using SmartSql;
using svc.App.Auth.Models.DTO;
using svc.App.Auth.Models.Entities;

namespace svc.App.Auth.Repositories;

/// <summary>
/// 사용자 리포지토리 클래스
/// </summary>
public class UserRepository : IUserRepository
{
    public ISqlMapper SqlMapper { get; }

    public UserRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    public Task<UserEntity?> GetUser(GetUserRequestDTO getUserRequestDTO)
    {
        return SqlMapper.QuerySingleAsync<UserEntity?>(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "GetUser",
            Request = getUserRequestDTO
        });
    }

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    public Task<int> AddUser(AddUserRequestDTO addUserRequestDTO)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "AddUser",
            Request = addUserRequestDTO
        });
    }

}
