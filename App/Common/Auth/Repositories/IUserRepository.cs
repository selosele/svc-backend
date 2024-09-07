using Svc.App.Common.Auth.Models.DTO;

namespace Svc.App.Common.Auth.Repositories;

/// <summary>
/// 사용자 리포지토리 인터페이스
/// </summary>
public interface IUserRepository
{
    #region Methods
    /// <summary>
    /// 사용자 목록을 조회한다.
    /// </summary>
    Task<IList<UserResponseDTO>> ListUser(GetUserRequestDTO? getUserRequestDTO);

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    Task<UserResponseDTO?> GetUser(GetUserRequestDTO getUserRequestDTO);

    /// <summary>
    /// 사용자를 조회한다(로그인용).
    /// </summary>
    Task<LoginResultDTO?> GetUserLogin(LoginRequestDTO loginRequestDTO);

    /// <summary>
    /// 사용자 비밀번호를 조회한다.
    /// </summary>
    Task<string> GetUserPassword(int? userId);

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    Task<int> AddUser(AddUserRequestDTO addUserRequestDTO);

    /// <summary>
    /// 사용자를 수정한다.
    /// </summary>
    Task<int> UpdateUser(UpdateUserRequestDTO updateUserRequestDTO);

    /// <summary>
    /// 사용자 마지막 로그인 일시를 변경한다.
    /// </summary>
    Task<int> UpdateUserLastLoginDt(int? userId, int updaterId);

    /// <summary>
    /// 사용자 비밀번호를 변경한다.
    /// </summary>
    Task<int> UpdateUserPassword(UpdateUserPasswordRequestDTO updateUserPasswordRequestDTO);

    /// <summary>
    /// 사용자를 삭제한다.
    /// </summary>
    Task<int> RemoveUser(int userId, int updaterId);
    #endregion

}
