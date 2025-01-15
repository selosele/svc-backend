namespace Svc.App.Common.Menu.Models.DTO;

/// <summary>
/// 메뉴 응답 DTO
/// </summary>
public record MenuResponseDTO
{
    #region [필드]
    /// <summary>
    /// 메뉴 ID
    /// </summary>
    public int? MenuId { get; set; }
    
    /// <summary>
    /// 상위 메뉴 ID
    /// </summary>
    public int? UpMenuId { get; set; }
    
    /// <summary>
    /// 메뉴명
    /// </summary>
    public string? MenuName { get; set; }
    
    /// <summary>
    /// 메뉴 URL
    /// </summary>
    public string? MenuUrl { get; set; }
    
    /// <summary>
    /// 메뉴 순서
    /// </summary>
    public int? MenuOrder { get; set; }
    
    /// <summary>
    /// 메뉴 뎁스
    /// </summary>
    public int? MenuDepth { get; set; }

    /// <summary>
    /// 메뉴 표출 여부
    /// </summary>
    public string? MenuShowYn { get; set; }
    
    /// <summary>
    /// 사용 여부
    /// </summary>
    public string? UseYn { get; set; }
    
    /// <summary>
    /// 삭제 여부
    /// </summary>
    public string? DeleteYn { get; set; }
    
    /// <summary>
    /// 메뉴 즐겨찾기 ID
    /// </summary>
    public int? MenuBookmarkId { get; set; }

    /// <summary>
    /// 메뉴 권한 목록
    /// </summary>
    public IList<MenuRoleResponseDTO>? MenuRoles { get; set; }
    #endregion

}
