using SmartSql;
using svc.App.Code.Models.DTO;

namespace svc.App.Code.Repositories;

/// <summary>
/// 코드 리포지토리 클래스
/// </summary>
public class CodeRepository : ICodeRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public CodeRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    public Task<IList<CodeResponseDTO>> ListCode()
    {
        return SqlMapper.QueryAsync<CodeResponseDTO>(new RequestContext
        {
            Scope = nameof(CodeRepository),
            SqlId = "ListCode"
        });
    }
    #endregion

}
