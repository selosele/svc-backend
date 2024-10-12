using SmartSql.AOP;
using Svc.App.Common.Role.Models.DTO;
using Svc.App.Common.Role.Mappers;

namespace Svc.App.Common.Role.Services;

/// <summary>
/// 권한 서비스 클래스
/// </summary>
public class RoleService
{
    #region Fields
    private readonly RoleMapper _roleMapper;
    #endregion
    
    #region Constructor
    public RoleService(
        RoleMapper roleMapper
    )
    {
        _roleMapper = roleMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 권한 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<RoleResponseDTO>> ListRole()
        => await _roleMapper.ListRole();
    #endregion
    
}
