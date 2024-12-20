using SmartSql;
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
    public Task<IList<CodeResponseDTO>> ListCode()
    {
        return SqlMapper.QueryAsync<CodeResponseDTO>(new RequestContext
        {
            Scope = nameof(CodeMapper),
            SqlId = "ListCode"
        });
    }

    /// <summary>
    /// 코드를 조회한다.
    /// </summary>
    public Task<CodeResponseDTO> GetCode(string codeId)
    {
        return SqlMapper.QuerySingleAsync<CodeResponseDTO>(new RequestContext
        {
            Scope = nameof(CodeMapper),
            SqlId = "GetCode",
            Request = new { codeId }
        });
    }

    /// <summary>
    /// 코드를 추가한다.
    /// </summary>
    public Task<string> AddCode(SaveCodeRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<string>(new RequestContext
        {
            Scope = nameof(CodeMapper),
            SqlId = "AddCode",
            Request = dto
        });
    }

    /// <summary>
    /// 코드를 수정한다.
    /// </summary>
    public Task<int> UpdateCode(SaveCodeRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(CodeMapper),
            SqlId = "UpdateCode",
            Request = dto
        });
    }

    /// <summary>
    /// 코드를 삭제한다.
    /// </summary>
    public Task<int> RemoveCode(string codeId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(CodeMapper),
            SqlId = "RemoveCode",
            Request = new { codeId }
        });
    }
    #endregion

}
