using SmartSql;
using Svc.App.Common.User.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 본인인증 내역 매퍼 클래스
/// </summary>
public class UserCertHistoryMapper : IUserCertHistoryMapper
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public UserCertHistoryMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 사용자 본인인증 내역을 조회한다.
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
    /// 사용자 본인인증 내역이 존재하는지 확인한다.
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
    /// 사용자 본인인증 내역을 추가한다.
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
