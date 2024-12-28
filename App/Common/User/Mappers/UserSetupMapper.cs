using SmartSql;
using Svc.App.Common.User.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 설정 매퍼 클래스
/// </summary>
public class UserSetupMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public UserSetupMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 사용자 설정을 조회한다.
    /// </summary>
    public Task<UserSetupResponseDTO> GetUserSetup(GetUserSetupRequestDTO dto)
    {
        return SqlMapper.QuerySingleAsync<UserSetupResponseDTO>(new RequestContext
        {
            Scope = nameof(UserSetupMapper),
            SqlId = "GetUserSetup",
            Request = dto
        });
    }

    /// <summary>
    /// 사용자 설정을 추가한다.
    /// </summary>
    public Task<int> AddUserSetup(AddUserSetupRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<int>(new RequestContext
        {
            Scope = nameof(UserSetupMapper),
            SqlId = "AddUserSetup",
            Request = dto
        });
    }
    #endregion

}
