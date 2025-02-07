namespace Svc.App.Common.Role.Models.DTO;

/// <summary>
/// 권한 응답 DTO
/// </summary>
public record RoleResponseDTO
{
    #region [필드]
    /// <summary>
    /// 권한
    /// </summary>
    public RoleResultDTO? Role { get; set; }

    /// <summary>
    /// 권한 목록
    /// </summary>
    public IList<RoleResultDTO>? RoleList { get; set; }
    #endregion
    
}
