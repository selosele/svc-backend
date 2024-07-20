using svc.App.Common.Code.Models.DTO;

namespace svc.App.Common.Code.Repositories;

/// <summary>
/// 코드 리포지토리 인터페이스
/// </summary>
public interface ICodeRepository
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
    #endregion

}
