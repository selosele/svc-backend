using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Article.Models.DTO;

/// <summary>
/// 게시글 조회 요청 DTO
/// </summary>
public record GetArticleRequestDTO : HttpRequestDTOBase
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
    /// 조회 개수
    /// </summary>
    public int? Limit { get; set; }
    #endregion
}
