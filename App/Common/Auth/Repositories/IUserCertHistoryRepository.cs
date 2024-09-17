using Svc.App.Common.Auth.Models.DTO;

namespace Svc.App.Common.Auth.Repositories;

/// <summary>
/// 사용자 본인인증 내역 리포지토리 인터페이스
/// </summary>
public interface IUserCertHistoryRepository
{
    #region Methods
    /// <summary>
    /// 사용자 본인인증 내역을 추가한다.
    /// </summary>
    Task<int> AddUserCertHistory(AddUserCertHistoryRequestDTO dto);
    #endregion

}
