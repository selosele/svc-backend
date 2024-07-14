using svc.App.Common.Auth.Models.DTO;

namespace svc.App.Common.Auth.Repositories;

/// <summary>
/// 사용자 리포지토리 인터페이스
/// </summary>
public interface IUserRepository
{
    #region Methods
    /// <summary>
    /// 사용자 목록을 조회한다.
    /// </summary>
    Task<IList<UserResponseDTO>> ListUser();

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    Task<UserResponseDTO?> GetUser(GetUserRequestDTO getUserRequestDTO);

    /// <summary>
    /// 사용자를 조회한다(로그인용).
    /// </summary>
    Task<LoginResultDTO?> GetUserLogin(GetUserRequestDTO getUserRequestDTO);

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    Task<int> AddUser(AddUserRequestDTO addUserRequestDTO);
    #endregion

}
