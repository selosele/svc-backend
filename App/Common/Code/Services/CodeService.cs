using SmartSql.AOP;
using Svc.App.Common.Code.Repositories;
using Svc.App.Common.Code.Models.DTO;

namespace Svc.App.Common.Code.Services;

/// <summary>
/// 코드 서비스 클래스
/// </summary>
public class CodeService
{
    #region Fields
    private readonly ICodeRepository _codeRepository;
    #endregion
    
    #region Constructor
    public CodeService(
        ICodeRepository codeRepository
    ) {
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

    /// <summary>
    /// 코드를 조회한다.
    /// </summary>
    [Transaction]
    public async Task<CodeResponseDTO> GetCode(string codeId)
        => await _codeRepository.GetCode(codeId);

    /// <summary>
    /// 코드를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<int> AddCode(SaveCodeRequestDTO saveCodeRequestDTO)
        => await _codeRepository.AddCode(saveCodeRequestDTO);

    /// <summary>
    /// 코드를 수정한다.
    /// </summary>
    [Transaction]
    public async Task<CodeResponseDTO> UpdateCode(SaveCodeRequestDTO saveCodeRequestDTO)
    {
        await _codeRepository.UpdateCode(saveCodeRequestDTO);
        return await _codeRepository.GetCode(saveCodeRequestDTO.CodeId!);
    }

    /// <summary>
    /// 코드를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveCode(string codeId)
        => await _codeRepository.RemoveCode(codeId);
    #endregion
    
}

