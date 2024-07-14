namespace svc.App.Common.Code.Models.DTO;

/// <summary>
/// 코드 응답 DTO
/// </summary>
public record CodeResponseDTO
{
    #region Fields
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
    /// 코드 명
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
    /// 코드 사용여부
    /// </summary>
    public string? CodeUseYn { get; set; }
    
    /// <summary>
    /// 코드 삭제여부
    /// </summary>
    public string? CodeDeleteYn { get; set; }
    #endregion
    
}
