using SmartSql;
using svc.App.Auth.Models.DTO;

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
    /// 사용자 목록을 조회한다.
    /// </summary>
    public Task<IList<UserResponseDTO>> ListUser()
    {
        return SqlMapper.QueryAsync<UserResponseDTO>(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "ListUser"
        });
    }

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    public Task<UserResponseDTO?> GetUser(GetUserRequestDTO getUserRequestDTO)
    {
        return SqlMapper.QuerySingleAsync<UserResponseDTO?>(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "GetUser",
            Request = getUserRequestDTO
        });
    }

    /// <summary>
    /// 사용자를 조회한다(로그인용).
    /// </summary>
    public Task<LoginResultDTO?> GetUserLogin(GetUserRequestDTO getUserRequestDTO)
    {
        return SqlMapper.QuerySingleAsync<LoginResultDTO?>(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "GetUserLogin",
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
