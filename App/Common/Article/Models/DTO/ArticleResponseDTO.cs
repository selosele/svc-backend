using Svc.App.Common.Board.Models.DTO;

namespace Svc.App.Common.Article.Models.DTO;

/// <summary>
/// 게시글 응답 DTO
/// </summary>
public record ArticleResponseDTO
{
    #region [필드]
    /// <summary>
    /// 게시판
    /// </summary>
    public BoardResponseDTO? Board { get; set; }

    /// <summary>
    /// 게시글 목록
    /// </summary>
    public IList<ArticleResultDTO>? ArticleList { get; set; }
    #endregion
    
}
