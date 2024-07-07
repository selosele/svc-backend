namespace svc.App.Auth.Models.DTO;

/// <summary>
/// 권한 응답 DTO
/// </summary>
public record RoleResponseDTO
{
    /// <summary>
    /// 권한 ID
    /// </summary>
    public string? RoleId { get; set; }

    /// <summary>
    /// 권한 명
    /// </summary>
    public string? RoleName { get; set; }

    /// <summary>
    /// 권한 순서
    /// </summary>
    public int? RoleOrder { get; set; }
    
}
