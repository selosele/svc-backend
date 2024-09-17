using SmartSql;
using Svc.App.Common.Auth.Models.DTO;

namespace Svc.App.Common.Auth.Repositories;

/// <summary>
/// 사용자 본인인증 내역 리포지토리 클래스
/// </summary>
public class UserCertHistoryRepository : IUserCertHistoryRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public UserCertHistoryRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 사용자 본인인증 내역을 추가한다.
    /// </summary>
    public Task<int> AddUserCertHistory(AddUserCertHistoryRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserCertHistoryRepository),
            SqlId = "AddUserCertHistory",
            Request = dto
        });
    }
    #endregion

}
