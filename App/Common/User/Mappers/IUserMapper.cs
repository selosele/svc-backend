using Svc.App.Common.User.Models.DTO;
using Svc.App.Common.Auth.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 매퍼 인터페이스
/// </summary>
public interface IUserMapper
{
    #region Methods
    /// <summary>
    /// 사용자 목록을 조회한다.
    /// </summary>
    Task<IList<UserResponseDTO>> ListUser(GetUserRequestDTO? dto);

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    Task<UserResponseDTO?> GetUser(GetUserRequestDTO dto);

    /// <summary>
    /// 사용자를 조회한다(로그인용).
    /// </summary>
    Task<LoginResultDTO?> GetUserLogin(LoginRequestDTO dto);

    /// <summary>
    /// 사용자를 조회한다(아이디/비밀번호 찾기용).
    /// </summary>
    Task<FindUserInfoResultDTO?> GetUserFindInfo(FindUserInfoRequestDTO dto);

    /// <summary>
    /// 사용자 비밀번호를 조회한다.
    /// </summary>
    Task<string> GetUserPassword(int? userId);

    /// <summary>
    /// 사용자 임시 비밀번호의 유효시간을 검증한다.
    /// </summary>
    Task<int> CountUserTempPasswordValid(int? userId);

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    Task<int> AddUser(AddUserRequestDTO dto);

    /// <summary>
    /// 사용자를 수정한다.
    /// </summary>
    Task<int> UpdateUser(UpdateUserRequestDTO dto);

    /// <summary>
    /// 사용자 마지막 로그인 일시를 변경한다.
    /// </summary>
    Task<int> UpdateUserLastLoginDt(int? userId, int? updaterId);

    /// <summary>
    /// 사용자 비밀번호를 변경한다.
    /// </summary>
    Task<int> UpdateUserPassword(UpdateUserPasswordRequestDTO dto);

    /// <summary>
    /// 사용자를 삭제한다.
    /// </summary>
    Task<int> RemoveUser(int userId, int? updaterId);
    #endregion

}
