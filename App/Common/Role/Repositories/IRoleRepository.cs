using Svc.App.Common.Role.Models.DTO;

namespace Svc.App.Common.Role.Repositories;

/// <summary>
/// 권한 리포지토리 인터페이스
/// </summary>
public interface IRoleRepository
{
    #region Methods
    /// <summary>
    /// 권한 목록을 조회한다.
    /// </summary>
    Task<IList<RoleResponseDTO>> ListRole();
    #endregion

}
