using SmartSql;
using Svc.App.Common.User.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 본인인증 이력 매퍼 클래스
/// </summary>
public class UserCertHistoryMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public UserCertHistoryMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 사용자 본인인증 이력을 조회한다.
    /// </summary>
    public Task<UserCertHistoryResponseDTO> GetUserCertHistory(GetUserCertHistoryRequestDTO dto)
    {
        return SqlMapper.QuerySingleAsync<UserCertHistoryResponseDTO>(new RequestContext
        {
            Scope = nameof(UserCertHistoryMapper),
            SqlId = "GetUserCertHistory",
            Request = dto
        });
    }

    /// <summary>
    /// 사용자 본인인증 이력이 존재하는지 확인한다.
    /// </summary>
    public Task<int> CountUserCertHistory(GetUserCertHistoryRequestDTO dto)
    {
        return SqlMapper.QuerySingleAsync<int>(new RequestContext
        {
            Scope = nameof(UserCertHistoryMapper),
            SqlId = "CountUserCertHistory",
            Request = dto
        });
    }

    /// <summary>
    /// 사용자 본인인증 이력을 추가한다.
    /// </summary>
    public Task<int> AddUserCertHistory(AddUserCertHistoryRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<int>(new RequestContext
        {
            Scope = nameof(UserCertHistoryMapper),
            SqlId = "AddUserCertHistory",
            Request = dto
        });
    }
    #endregion

}
