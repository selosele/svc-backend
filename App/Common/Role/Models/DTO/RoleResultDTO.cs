namespace Svc.App.Common.Role.Models.DTO;

/// <summary>
/// 권한 조회 결과 DTO
/// </summary>
public record RoleResultDTO
{
    #region [필드]
    /// <summary>
    /// 권한 ID
    /// </summary>
    public string? RoleId { get; set; }

    /// <summary>
    /// 권한명
    /// </summary>
    public string? RoleName { get; set; }

    /// <summary>
    /// 권한 순서
    /// </summary>
    public int? RoleOrder { get; set; }
    #endregion
    
}
