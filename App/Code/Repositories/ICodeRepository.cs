using svc.App.Code.Models.DTO;

namespace svc.App.Code.Repositories;

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
    #endregion

}
