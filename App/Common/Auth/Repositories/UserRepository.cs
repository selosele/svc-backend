using SmartSql;
using Svc.App.Common.Auth.Models.DTO;

namespace Svc.App.Common.Auth.Repositories;

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
    public Task<IList<UserResponseDTO>> ListUser(GetUserRequestDTO? dto)
    {
        return SqlMapper.QueryAsync<UserResponseDTO>(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "ListUser",
            Request = dto
        });
    }

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    public Task<UserResponseDTO?> GetUser(GetUserRequestDTO dto)
    {
        return SqlMapper.QuerySingleAsync<UserResponseDTO?>(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "GetUser",
            Request = dto
        });
    }

    /// <summary>
    /// 사용자를 조회한다(로그인용).
    /// </summary>
    public Task<LoginResultDTO?> GetUserLogin(LoginRequestDTO dto)
    {
        return SqlMapper.QuerySingleAsync<LoginResultDTO?>(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "GetUserLogin",
            Request = dto
        });
    }

    /// <summary>
    /// 사용자 비밀번호를 조회한다.
    /// </summary>
    public Task<string> GetUserPassword(int? userId)
    {
        return SqlMapper.QuerySingleAsync<string>(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "GetUserPassword",
            Request = new { userId }
        });
    }

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    public Task<int> AddUser(AddUserRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<int>(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "AddUser",
            Request = dto
        });
    }

    /// <summary>
    /// 사용자를 수정한다.
    /// </summary>
    public Task<int> UpdateUser(UpdateUserRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "UpdateUser",
            Request = dto
        });
    }

    /// <summary>
    /// 사용자 마지막 로그인 일시를 변경한다.
    /// </summary>
    public Task<int> UpdateUserLastLoginDt(int? userId, int updaterId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "UpdateUserLastLoginDt",
            Request = new { userId, updaterId }
        });
    }

    /// <summary>
    /// 사용자 비밀번호를 변경한다.
    /// </summary>
    public Task<int> UpdateUserPassword(UpdateUserPasswordRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserRepository),
            SqlId = "UpdateUserPassword",
            Request = dto
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
            Request = new { userId, updaterId }
        });
    }
    #endregion

}
