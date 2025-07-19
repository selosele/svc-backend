using SmartSql.AOP;
using Svc.App.Common.Code.Mappers;
using Svc.App.Common.Code.Models.DTO;

namespace Svc.App.Common.Code.Services;

/// <summary>
/// 코드 서비스
/// </summary>
public class CodeService(CodeMapper codeMapper)
{
    #region [필드]
    private readonly CodeMapper _codeMapper = codeMapper;
    #endregion

    #region [메서드]
    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    public async Task<IList<CodeResultDTO>> ListCode()
        => await _codeMapper.ListCode();

    /// <summary>
    /// 코드를 조회한다.
    /// </summary>
    public async Task<CodeResultDTO> GetCode(string codeId)
        => await _codeMapper.GetCode(codeId);

    /// <summary>
    /// 코드를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<CodeResultDTO> AddCode(SaveCodeRequestDTO dto)
    {
        var codeId = await _codeMapper.AddCode(dto);
        return await _codeMapper.GetCode(codeId);
    }

    /// <summary>
    /// 코드를 수정한다.
    /// </summary>
    [Transaction]
    public async Task<CodeResultDTO> UpdateCode(SaveCodeRequestDTO dto)
    {
        await _codeMapper.UpdateCode(dto);
        return await _codeMapper.GetCode(dto.CodeId!);
    }

    /// <summary>
    /// 코드를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveCode(string codeId)
        => await _codeMapper.RemoveCode(codeId);
    #endregion
    
}

