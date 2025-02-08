using SmartSql;
using Svc.App.Common.User.Models.DTO;
using Svc.App.Common.Auth.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 매퍼 클래스
/// </summary>
public class UserMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public UserMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 사용자 목록을 조회한다.
    /// </summary>
    public Task<IList<UserResultDTO>> ListUser(GetUserRequestDTO? dto)
    {
        return SqlMapper.QueryAsync<UserResultDTO>(new RequestContext
        {
            Scope = nameof(UserMapper),
            SqlId = "ListUser",
            Request = dto
        });
    }

    /// <summary>
    /// 메뉴별 사용자 목록을 조회한다.
    /// </summary>
    public Task<IList<UserResultDTO>> ListUserByMenu(int? menuId)
    {
        return SqlMapper.QueryAsync<UserResultDTO>(new RequestContext
        {
            Scope = nameof(UserMapper),
            SqlId = "ListUserByMenu",
            Request = new { menuId }
        });
    }

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    public Task<UserResultDTO?> GetUser(GetUserRequestDTO dto)
    {
        return SqlMapper.QuerySingleAsync<UserResultDTO?>(new RequestContext
        {
            Scope = nameof(UserMapper),
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
            Scope = nameof(UserMapper),
            SqlId = "GetUserLogin",
            Request = dto
        });
    }

    /// <summary>
    /// 사용자를 조회한다(아이디 찾기용).
    /// </summary>
    public Task<FindUserInfoResultDTO?> GetUserFindInfo(FindUserInfoRequestDTO dto)
    {
        return SqlMapper.QuerySingleAsync<FindUserInfoResultDTO?>(new RequestContext
        {
            Scope = nameof(UserMapper),
            SqlId = "GetUserFindInfo",
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
            Scope = nameof(UserMapper),
            SqlId = "GetUserPassword",
            Request = new { userId }
        });
    }

    /// <summary>
    /// 사용자 임시 비밀번호의 유효시간을 검증한다.
    /// </summary>
    public Task<int> CountUserTempPasswordValid(int? userId)
    {
        return SqlMapper.QuerySingleAsync<int>(new RequestContext
        {
            Scope = nameof(UserMapper),
            SqlId = "CountUserTempPasswordValid",
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
            Scope = nameof(UserMapper),
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
            Scope = nameof(UserMapper),
            SqlId = "UpdateUser",
            Request = dto
        });
    }

    /// <summary>
    /// 사용자 마지막 로그인 일시를 변경한다.
    /// </summary>
    public Task<int> UpdateUserLastLoginDt(int? userId, int? updaterId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserMapper),
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
            Scope = nameof(UserMapper),
            SqlId = "UpdateUserPassword",
            Request = dto
        });
    }

    /// <summary>
    /// 사용자를 삭제한다.
    /// </summary>
    public Task<int> RemoveUser(int userId, int? updaterId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserMapper),
            SqlId = "RemoveUser",
            Request = new { userId, updaterId }
        });
    }
    #endregion

}
