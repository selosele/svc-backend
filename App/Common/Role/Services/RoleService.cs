using SmartSql.AOP;
using Svc.App.Common.Role.Models.DTO;
using Svc.App.Common.Role.Mappers;

namespace Svc.App.Common.Role.Services;

/// <summary>
/// 권한 서비스 클래스
/// </summary>
public class RoleService
{
    #region [필드]
    private readonly RoleMapper _roleMapper;
    #endregion
    
    #region [생성자]
    public RoleService(
        RoleMapper roleMapper
    )
    {
        _roleMapper = roleMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 권한 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<RoleResultDTO>> ListRole()
        => await _roleMapper.ListRole();
    #endregion
    
}
