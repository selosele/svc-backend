using SmartSql.AOP;
using svc.App.Code.Repositories;
using svc.App.Code.Models.DTO;

namespace svc.App.Code.Services;

/// <summary>
/// 코드 서비스 클래스
/// </summary>
public class CodeService
{
    #region Fields
    private readonly ICodeRepository _codeRepository;
    #endregion
    
    #region Constructor
    public CodeService(ICodeRepository codeRepository)
    {
        _codeRepository = codeRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<CodeResponseDTO>> ListCode()
        => await _codeRepository.ListCode();
    #endregion
    
}

