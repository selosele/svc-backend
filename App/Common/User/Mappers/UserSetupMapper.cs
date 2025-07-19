using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Common.User.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 설정 매퍼
/// </summary>
public class UserSetupMapper(ISqlMapper sqlMapper) : MyMapperBase(sqlMapper)
{
    #region [메서드]
    /// <summary>
    /// 사용자 설정을 조회한다.
    /// </summary>
    public Task<UserSetupResultDTO> GetUserSetup(GetUserSetupRequestDTO dto)
        => QueryForObject<UserSetupResultDTO>($"{nameof(UserSetupMapper)}.GetUserSetup", dto);

    /// <summary>
    /// 사용자 설정을 추가한다.
    /// </summary>
    public Task<int> AddUserSetup(AddUserSetupRequestDTO dto)
        => ExecuteScalar<int>($"{nameof(UserSetupMapper)}.AddUserSetup", dto);
    #endregion

}
