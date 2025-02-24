using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Common.User.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 본인인증 이력 매퍼 클래스
/// </summary>
public class UserCertHistoryMapper : MyMapperBase
{
    #region [생성자]
    public UserCertHistoryMapper(ISqlMapper sqlMapper) : base(sqlMapper) {}
    #endregion

    #region [메서드]
    /// <summary>
    /// 사용자 본인인증 이력을 조회한다.
    /// </summary>
    public Task<UserCertHistoryResultDTO> GetUserCertHistory(GetUserCertHistoryRequestDTO dto)
        => QueryForObject<UserCertHistoryResultDTO>($"{nameof(UserCertHistoryMapper)}.GetUserCertHistory", dto);

    /// <summary>
    /// 사용자 본인인증 이력이 존재하는지 확인한다.
    /// </summary>
    public Task<int> CountUserCertHistory(GetUserCertHistoryRequestDTO dto)
        => QueryForObject<int>($"{nameof(UserCertHistoryMapper)}.CountUserCertHistory", dto);

    /// <summary>
    /// 사용자 본인인증 이력을 추가한다.
    /// </summary>
    public Task<int> AddUserCertHistory(AddUserCertHistoryRequestDTO dto)
        => ExecuteScalar<int>($"{nameof(UserCertHistoryMapper)}.AddUserCertHistory", dto);
    #endregion

}
