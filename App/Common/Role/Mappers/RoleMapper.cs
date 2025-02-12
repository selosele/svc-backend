using SmartSql;
using Svc.App.Shared.Extensions;
using Svc.App.Common.Role.Models.DTO;

namespace Svc.App.Common.Role.Mappers;

/// <summary>
/// 권한 매퍼 클래스
/// </summary>
public class RoleMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public RoleMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 권한 목록을 조회한다.
    /// </summary>
    public Task<IList<RoleResultDTO>> ListRole()
        => SqlMapper.QueryForList<RoleResultDTO>(nameof(RoleMapper), "ListRole");
    #endregion

}
