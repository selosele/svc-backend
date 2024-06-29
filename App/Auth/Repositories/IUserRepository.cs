using svc.App.Auth.Models.DTO;
using svc.App.Auth.Models.Entities;

namespace svc.App.Auth.Repositories;

/// <summary>
/// 사용자 리포지토리 인터페이스
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    Task<UserEntity?> GetUser(GetUserRequestDTO getUserRequestDTO);

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    Task<int> AddUser(AddUserRequestDTO addUserRequestDTO);

}
