using Svc.App.Common.Code.Models.DTO;

namespace Svc.App.Common.Code.Mappers;

/// <summary>
/// 코드 매퍼 인터페이스
/// </summary>
public interface ICodeMapper
{
    #region Methods
    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    Task<IList<CodeResponseDTO>> ListCode();

    /// <summary>
    /// 코드를 조회한다.
    /// </summary>
    Task<CodeResponseDTO> GetCode(string codeId);

    /// <summary>
    /// 코드를 추가한다.
    /// </summary>
    Task<string> AddCode(SaveCodeRequestDTO dto);

    /// <summary>
    /// 코드를 수정한다.
    /// </summary>
    Task<int> UpdateCode(SaveCodeRequestDTO dto);

    /// <summary>
    /// 코드를 삭제한다.
    /// </summary>
    Task<int> RemoveCode(string codeId);
    #endregion

}
