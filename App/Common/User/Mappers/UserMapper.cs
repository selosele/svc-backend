using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Common.User.Models.DTO;
using Svc.App.Common.Auth.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 매퍼 클래스
/// </summary>
public class UserMapper : MyMapperBase
{
    #region [생성자]
    public UserMapper(ISqlMapper sqlMapper) : base(sqlMapper) {}
    #endregion

    #region [메서드]
    /// <summary>
    /// 사용자 목록을 조회한다.
    /// </summary>
    public Task<IList<UserResultDTO>> ListUser(GetUserRequestDTO? dto)
        => QueryForList<UserResultDTO>($"{nameof(UserMapper)}.ListUser", dto);

    /// <summary>
    /// 메뉴별 사용자 목록을 조회한다.
    /// </summary>
    public Task<IList<UserResultDTO>> ListUserByMenu(int? menuId)
        => QueryForList<UserResultDTO>($"{nameof(UserMapper)}.ListUserByMenu", new { menuId });

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    public Task<UserResultDTO?> GetUser(GetUserRequestDTO dto)
        => QueryForObject<UserResultDTO?>($"{nameof(UserMapper)}.GetUser", dto);

    /// <summary>
    /// 사용자를 조회한다(로그인용).
    /// </summary>
    public Task<LoginResultDTO?> GetUserLogin(LoginRequestDTO dto)
        => QueryForObject<LoginResultDTO?>($"{nameof(UserMapper)}.GetUserLogin", dto);

    /// <summary>
    /// 사용자를 조회한다(아이디 찾기용).
    /// </summary>
    public Task<FindUserInfoResultDTO?> GetUserFindInfo(FindUserInfoRequestDTO dto)
        => QueryForObject<FindUserInfoResultDTO?>($"{nameof(UserMapper)}.GetUserFindInfo", dto);

    /// <summary>
    /// 사용자 비밀번호를 조회한다.
    /// </summary>
    public Task<string> GetUserPassword(int? userId)
        => QueryForObject<string>($"{nameof(UserMapper)}.GetUserPassword", new { userId });

    /// <summary>
    /// 사용자 임시 비밀번호의 유효시간을 검증한다.
    /// </summary>
    public Task<int> CountUserTempPasswordValid(int? userId)
        => QueryForObject<int>($"{nameof(UserMapper)}.CountUserTempPasswordValid", new { userId });

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    public Task<int> AddUser(AddUserRequestDTO dto)
        => ExecuteScalar<int>($"{nameof(UserMapper)}.AddUser", dto);

    /// <summary>
    /// 사용자를 수정한다.
    /// </summary>
    public Task<int> UpdateUser(UpdateUserRequestDTO dto)
        => Execute($"{nameof(UserMapper)}.UpdateUser", dto);

    /// <summary>
    /// 사용자 마지막 로그인 일시를 변경한다.
    /// </summary>
    public Task<int> UpdateUserLastLoginDt(int? userId, int? updaterId)
        => Execute($"{nameof(UserMapper)}.UpdateUserLastLoginDt", new { userId, updaterId });

    /// <summary>
    /// 사용자 비밀번호를 변경한다.
    /// </summary>
    public Task<int> UpdateUserPassword(UpdateUserPasswordRequestDTO dto)
        => Execute($"{nameof(UserMapper)}.UpdateUserPassword", dto);

    /// <summary>
    /// 사용자를 삭제한다.
    /// </summary>
    public Task<int> RemoveUser(int userId, int? updaterId)
        => Execute($"{nameof(UserMapper)}.RemoveUser", new { userId, updaterId });
    #endregion

}
