using Svc.App.Common.Role.Models.DTO;

namespace Svc.App.Common.Role.Mappers;

/// <summary>
/// 권한 매퍼 인터페이스
/// </summary>
public interface IRoleMapper
{
    #region Methods
    /// <summary>
    /// 권한 목록을 조회한다.
    /// </summary>
    Task<IList<RoleResponseDTO>> ListRole();
    #endregion

}
