using SmartSql;
using Svc.App.Shared.Extensions;
using Svc.App.Common.Code.Models.DTO;

namespace Svc.App.Common.Code.Mappers;

/// <summary>
/// 코드 매퍼 클래스
/// </summary>
public class CodeMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public CodeMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    public Task<IList<CodeResultDTO>> ListCode()
        => SqlMapper.QueryForList<CodeResultDTO>(nameof(CodeMapper), "ListCode");

    /// <summary>
    /// 코드를 조회한다.
    /// </summary>
    public Task<CodeResultDTO> GetCode(string codeId)
        => SqlMapper.QueryForObject<CodeResultDTO>(nameof(CodeMapper), "GetCode", new { codeId });

    /// <summary>
    /// 코드를 추가한다.
    /// </summary>
    public Task<string> AddCode(SaveCodeRequestDTO dto)
        => SqlMapper.ExecuteScalar<string>(nameof(CodeMapper), "AddCode", dto);

    /// <summary>
    /// 코드를 수정한다.
    /// </summary>
    public Task<int> UpdateCode(SaveCodeRequestDTO dto)
        => SqlMapper.Execute(nameof(CodeMapper), "UpdateCode", dto);

    /// <summary>
    /// 코드를 삭제한다.
    /// </summary>
    public Task<int> RemoveCode(string codeId)
        => SqlMapper.Execute(nameof(CodeMapper), "RemoveCode", new { codeId });
    #endregion

}
