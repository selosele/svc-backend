using svc.App.Auth.Models.DTO;

namespace svc.App.Auth.Repositories;

/// <summary>
/// 사용자 메뉴 권한 리포지토리 인터페이스
/// </summary>
public interface IUserMenuRoleRepository
{
    /// <summary>
    /// 사용자 메뉴 권한을 추가한다.
    /// </summary>
    Task<int> AddUserMenuRole(AddUserMenuRoleRequestDTO addUserMenuRoleRequestDTO);

}
