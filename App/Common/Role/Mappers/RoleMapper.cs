using SmartSql;
using Svc.App.Common.Role.Models.DTO;

namespace Svc.App.Common.Role.Mappers;

/// <summary>
/// 권한 매퍼 클래스
/// </summary>
public class RoleMapper
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public RoleMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 권한 목록을 조회한다.
    /// </summary>
    public Task<IList<RoleResponseDTO>> ListRole()
    {
        return SqlMapper.QueryAsync<RoleResponseDTO>(new RequestContext
        {
            Scope = nameof(RoleMapper),
            SqlId = "ListRole"
        });
    }
    #endregion

}
