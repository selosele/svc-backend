using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Article.Models.DTO;

/// <summary>
/// 게시글 추가/수정 요청 DTO
/// </summary>
public record SaveArticleRequestDTO : HttpRequestDTOBase
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
    /// 게시글 작성자 닉네임
    /// </summary>
    public string? ArticleWriterNickname { get; set; }
    #endregion
}
