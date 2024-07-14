using svc.App.Common.Auth.Models.DTO;

namespace svc.App.Common.Auth.Repositories;

/// <summary>
/// 사용자 메뉴 권한 리포지토리 인터페이스
/// </summary>
public interface IUserMenuRoleRepository
{
    #region Methods
    /// <summary>
    /// 사용자 메뉴 권한을 추가한다.
    /// </summary>
    Task<int> AddUserMenuRole(AddUserMenuRoleRequestDTO addUserMenuRoleRequestDTO);
    #endregion

}
