namespace Svc.App.Common.Board.Models.DTO;

/// <summary>
/// 게시판 응답 DTO
/// </summary>
public record BoardResponseDTO
{
    #region [필드]
    /// <summary>
    /// 게시판 ID
    /// </summary>
    public int? BoardId { get; set; }
    
    /// <summary>
    /// 게시판명
    /// </summary>
    public string? BoardName { get; set; }
    
    /// <summary>
    /// 게시판 내용
    /// </summary>
    public string? BoardContent { get; set; }
    
    /// <summary>
    /// 게시판 구분 코드
    /// </summary>
    public string? BoardTypeCode { get; set; }
    
    /// <summary>
    /// 게시판 구분 코드명
    /// </summary>
    public string? BoardTypeCodeName { get; set; }
    
    /// <summary>
    /// 게시판 순서
    /// </summary>
    public int? BoardOrder { get; set; }

    /// <summary>
    /// 메인 화면 표출 여부
    /// </summary>
    public string? MainShowYn { get; set; }
    
    /// <summary>
    /// 사용 여부
    /// </summary>
    public string? UseYn { get; set; }
    #endregion
    
}
