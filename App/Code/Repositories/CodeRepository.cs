using SmartSql;
using svc.App.Code.Models.Entities;

namespace svc.App.Code.Repositories;

/// <summary>
/// 코드 리포지토리 클래스
/// </summary>
public class CodeRepository : ICodeRepository
{
    public ISqlMapper SqlMapper { get; }

    public CodeRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }

    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    public Task<IList<CodeEntity>> ListCode()
    {
        return SqlMapper.QueryAsync<CodeEntity>(new RequestContext
        {
            Scope = nameof(CodeRepository),
            SqlId = "ListCode"
        });
    }

}
