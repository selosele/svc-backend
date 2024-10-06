using SmartSql.AOP;
using Svc.App.Common.Role.Models.DTO;
using Svc.App.Common.Role.Repositories;

namespace Svc.App.Common.Role.Services;

/// <summary>
/// 권한 서비스 클래스
/// </summary>
public class RoleService
{
    #region Fields
    private readonly IRoleRepository _roleRepository;
    #endregion
    
    #region Constructor
    public RoleService(
        IRoleRepository roleRepository
    )
    {
        _roleRepository = roleRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 권한 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<RoleResponseDTO>> ListRole()
        => await _roleRepository.ListRole();
    #endregion
    
}
