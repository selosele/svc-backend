using svc.App.Code.Models.Entities;
using svc.App.Code.Repositories;

namespace svc.App.Code.Services;

public class CodeService : ICodeService
{
    private readonly ICodeRepository _codeRepository;
    public CodeService(ICodeRepository codeRepository)
    {
        _codeRepository = codeRepository;
    }

    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    public async Task<List<CodeEntity>> ListCode()
    {
        return await _codeRepository.ListCode();
    }
}
