using Svc.App.Human.Employee.Models.DTO;

namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 응답 DTO
/// </summary>
public record UserResponseDTO
{
    #region [필드]
    /// <summary>
    /// 사용자
    /// </summary>
    public UserResultDTO? User { get; set; }

    /// <summary>
    /// 사용자 목록
    /// </summary>
    public IList<UserResultDTO>? UserList { get; set; }
    #endregion
    
}
