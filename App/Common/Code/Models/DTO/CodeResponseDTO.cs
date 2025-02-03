namespace Svc.App.Common.Code.Models.DTO;

/// <summary>
/// 코드 응답 DTO
/// </summary>
public record CodeResponseDTO
{
    #region [필드]
    /// <summary>
    /// 코드 ID
    /// </summary>
    public string? CodeId { get; set; }
    
    /// <summary>
    /// 상위 코드 ID
    /// </summary>
    public string? UpCodeId { get; set; }
    
    /// <summary>
    /// 코드 값
    /// </summary>
    public string? CodeValue { get; set; }
    
    /// <summary>
    /// 코드명
    /// </summary>
    public string? CodeName { get; set; }
    
    /// <summary>
    /// 코드 내용
    /// </summary>
    public string? CodeContent { get; set; }
    
    /// <summary>
    /// 코드 순서
    /// </summary>
    public int? CodeOrder { get; set; }
    
    /// <summary>
    /// 코드 뎁스
    /// </summary>
    public int? CodeDepth { get; set; }
    
    /// <summary>
    /// 사용 여부
    /// </summary>
    public string? UseYn { get; set; }

    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }
    #endregion
    
}
