namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 권한 응답 DTO
/// </summary>
public record UserRoleResponseDTO
{
    #region [필드]
    /// <summary>
    /// 사용자 권한
    /// </summary>
    public UserRoleResultDTO? UserRole { get; set; }

    /// <summary>
    /// 사용자 권한 목록
    /// </summary>
    public IList<UserRoleResultDTO>? UserRoleList { get; set; }
    #endregion

}
