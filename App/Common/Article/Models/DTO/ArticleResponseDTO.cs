namespace Svc.App.Common.Article.Models.DTO;

/// <summary>
/// 게시글 응답 DTO
/// </summary>
public record ArticleResponseDTO
{
    #region [필드]
    /// <summary>
    /// 게시글 ID
    /// </summary>
    public int? ArticleId { get; set; }

    /// <summary>
    /// 게시판 ID
    /// </summary>
    public int? BoardId { get; set; }
    
    /// <summary>
    /// 게시글 제목
    /// </summary>
    public string? ArticleTitle { get; set; }
    
    /// <summary>
    /// 게시글 내용
    /// </summary>
    public string? ArticleContent { get; set; }
    
    /// <summary>
    /// 게시글 작성자 ID
    /// </summary>
    public int? ArticleWriterId { get; set; }
    
    /// <summary>
    /// 게시글 작성자명
    /// </summary>
    public string? ArticleWriterName { get; set; }
    
    /// <summary>
    /// 게시판 내용
    /// </summary>
    public string? BoardContent { get; set; }
    
    /// <summary>
    /// 게시판 구분 코드
    /// </summary>
    public string? BoardTypeCode { get; set; }
    
    /// <summary>
    /// 등록일시
    /// </summary>
    public string? CreateDt { get; set; }
    #endregion
    
}
