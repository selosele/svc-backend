using SmartSql;
using svc.App.Auth.Models.DTO;

namespace svc.App.Auth.Repositories;

/// <summary>
/// 사용자 리포지토리 클래스
/// </summary>
public class RoleRepository : IRoleRepository
{
    public ISqlMapper SqlMapper { get; }

    public RoleRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }

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

}
