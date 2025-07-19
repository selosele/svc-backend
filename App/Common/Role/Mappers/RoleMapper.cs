using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Common.Role.Models.DTO;

namespace Svc.App.Common.Role.Mappers;

/// <summary>
/// 권한 매퍼
/// </summary>
public class RoleMapper(ISqlMapper sqlMapper) : MyMapperBase(sqlMapper)
{
    #region [메서드]
    /// <summary>
    /// 권한 목록을 조회한다.
    /// </summary>
    public Task<IList<RoleResultDTO>> ListRole()
        => QueryForList<RoleResultDTO>($"{nameof(RoleMapper)}.ListRole");
    #endregion

}
