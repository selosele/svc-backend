using SmartSql;
using svc.App.Common.Auth.Models.DTO;

namespace svc.App.Common.Auth.Repositories;

/// <summary>
/// 사용자 리포지토리 클래스
/// </summary>
public class RoleRepository : IRoleRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public RoleRepository(ISqlMapper sqlMapper)
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
            Scope = nameof(RoleRepository),
            SqlId = "ListRole"
        });
    }
    #endregion

}
