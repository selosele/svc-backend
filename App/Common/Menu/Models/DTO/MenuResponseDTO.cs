namespace svc.App.Common.Menu.Models.DTO;

/// <summary>
/// 메뉴 응답 DTO
/// </summary>
public record MenuResponseDTO
{
    #region Fields
    /// <summary>
    /// 메뉴 ID
    /// </summary>
    public int? MenuId { get; set; }
    
    /// <summary>
    /// 상위 메뉴 ID
    /// </summary>
    public int? UpMenuId { get; set; }
    
    /// <summary>
    /// 메뉴 명
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
    /// 메뉴 사용여부
    /// </summary>
    public string? MenuUseYn { get; set; }
    
    /// <summary>
    /// 메뉴 삭제여부
    /// </summary>
    public string? MenuDeleteYn { get; set; }
    #endregion

}
