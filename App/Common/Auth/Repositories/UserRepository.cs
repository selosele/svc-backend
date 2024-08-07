using SmartSql;
using svc.App.Common.Auth.Models.DTO;

namespace svc.App.Common.Auth.Repositories;

/// <summary>
/// 사용자 리포지토리 클래스
/// </summary>
public class UserRepository : IUserRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public UserRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 사용자 목록을 조회한다.
    /// </summary>
    public Task<IList<UserResponseDTO>> ListUser(GetUserRequestDTO? getUserRequestDTO)
    {
        return SqlMapper.QueryAsync<UserResponseDTO>(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "ListUser",
            Request = getUserRequestDTO
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
    public Task<LoginResultDTO?> GetUserLogin(LoginRequestDTO loginRequestDTO)
    {
        return SqlMapper.QuerySingleAsync<LoginResultDTO?>(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "GetUserLogin",
            Request = loginRequestDTO
        });
    }

    /// <summary>
    /// 사용자 비밀번호를 조회한다.
    /// </summary>
    public Task<GetUserPasswordResultDTO> GetUserPassword(int? userId)
    {
        return SqlMapper.QuerySingleAsync<GetUserPasswordResultDTO>(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "GetUserPassword",
            Request = userId
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

    /// <summary>
    /// 사용자를 수정한다.
    /// </summary>
    public Task<int> UpdateUser(UpdateUserRequestDTO updateUserRequestDTO)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "UpdateUser",
            Request = updateUserRequestDTO
        });
    }

    /// <summary>
    /// 사용자 비밀번호를 변경한다.
    /// </summary>
    public Task<int> UpdateUserPassword(UpdateUserPasswordRequestDTO updateUserPasswordRequestDTO)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "UpdateUserPassword",
            Request = updateUserPasswordRequestDTO
        });
    }

    /// <summary>
    /// 사용자를 삭제한다.
    /// </summary>
    public Task<int> RemoveUser(int userId, int updaterId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "RemoveUser",
            Request = new { UserId = userId, UpdaterId = updaterId }
        });
    }
    #endregion

}
