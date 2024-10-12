using Svc.App.Common.User.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 본인인증 내역 매퍼 인터페이스
/// </summary>
public interface IUserCertHistoryMapper
{
    #region Methods
    /// <summary>
    /// 사용자 본인인증 내역을 조회한다.
    /// </summary>
    Task<UserCertHistoryResponseDTO> GetUserCertHistory(GetUserCertHistoryRequestDTO dto);

    /// <summary>
    /// 사용자 본인인증 내역이 존재하는지 확인한다.
    /// </summary>
    Task<int> CountUserCertHistory(GetUserCertHistoryRequestDTO dto);

    /// <summary>
    /// 사용자 본인인증 내역을 추가한다.
    /// </summary>
    Task<int> AddUserCertHistory(AddUserCertHistoryRequestDTO dto);
    #endregion

}
