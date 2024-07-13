namespace svc.App.Auth.Models.DTO;

/// <summary>
/// 로그인 결과 DTO
/// </summary>
public record LoginResultDTO
{
    #region Fields
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 사용자 계정
    /// </summary>
    public string? UserAccount { get; set; }

    /// <summary>
    /// 사용자 비밀번호
    /// </summary>
    public string? UserPassword { get; set; }

    /// <summary>
    /// 사용자 명
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// 사용자 활성화 여부
    /// </summary>
    public string? UserActiveYn { get; set; }

    /// <summary>
    /// 사용자 권한 목록
    /// </summary>
    public IList<UserRoleResponseDTO>? Roles { get; set; } = [];
    #endregion
    
}
