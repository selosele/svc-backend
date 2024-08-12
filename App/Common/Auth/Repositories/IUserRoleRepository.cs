using svc.App.Common.Auth.Models.DTO;

namespace svc.App.Common.Auth.Repositories;

/// <summary>
/// 사용자 권한 리포지토리 인터페이스
/// </summary>
public interface IUserRoleRepository
{
    #region Methods
    /// <summary>
    /// 사용자 권한 목록을 조회한다.
    /// </summary>
    Task<IList<UserRoleResponseDTO>> ListUserRole(GetUserRoleRequestDTO getUserRoleRequestDTO);

    /// <summary>
    /// 사용자 권한을 추가한다.
    /// </summary>
    Task<int> AddUserRole(List<AddUserRoleRequestDTO> addUserRoleRequestDTOList);

    /// <summary>
    /// 사용자 권한을 삭제한다.
    /// </summary>
    Task<int> RemoveUserRole(int? userId);
    #endregion

}
