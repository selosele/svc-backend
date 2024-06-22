namespace svc.App.Auth.Models.DTO;

/// <summary>
/// 사용자 추가 요청 DTO
/// </summary>
public record AddUserRequestDTO : GetUserRequestDTO
{
    /// <summary>
    /// 권한 ID 목록
    /// </summary>
    public List<string>? RoleIdList { get; set; }

}
