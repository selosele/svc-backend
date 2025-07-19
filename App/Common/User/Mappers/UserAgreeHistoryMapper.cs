using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Common.User.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 동의 이력 매퍼
/// </summary>
public class UserAgreeHistoryMapper(ISqlMapper sqlMapper) : MyMapperBase(sqlMapper)
{
    #region [메서드]
    /// <summary>
    /// 사용자 동의 이력을 추가한다.
    /// </summary>
    public Task<int> AddUserAgreeHistory(AddUserAgreeHistoryRequestDTO dto)
        => ExecuteScalar<int>($"{nameof(UserAgreeHistoryMapper)}.AddUserAgreeHistory", dto);
    #endregion

}
