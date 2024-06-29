using svc.App.Code.Models.Entities;
using svc.App.Code.Repositories;
using SmartSql.AOP;

namespace svc.App.Code.Services;

/// <summary>
/// 코드 서비스 클래스
/// </summary>
public class CodeService
{
    private readonly ICodeRepository _codeRepository;
    
    public CodeService(ICodeRepository codeRepository)
    {
        _codeRepository = codeRepository;
    }

    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<CodeEntity>> ListCode()
    {
        return await _codeRepository.ListCode();
    }
    
}

