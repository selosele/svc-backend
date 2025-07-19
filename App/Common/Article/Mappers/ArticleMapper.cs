using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Common.Article.Models.DTO;

namespace Svc.App.Common.Article.Mappers;

/// <summary>
/// 게시글 매퍼
/// </summary>
public class ArticleMapper(ISqlMapper sqlMapper) : MyMapperBase(sqlMapper)
{
    #region [메서드]
    /// <summary>
    /// 게시글 목록을 조회한다.
    /// </summary>
    public Task<IList<ArticleResultDTO>> ListArticle(GetArticleRequestDTO dto)
        => QueryForList<ArticleResultDTO>($"{nameof(ArticleMapper)}.ListArticle", dto);

    /// <summary>
    /// 이전/다음 게시글 목록을 조회한다.
    /// </summary>
    public Task<IList<ArticleResultDTO>> ListPrevNextArticle(GetArticleRequestDTO dto)
        => QueryForList<ArticleResultDTO>($"{nameof(ArticleMapper)}.ListPrevNextArticle", dto);

    /// <summary>
    /// 게시글을 조회한다.
    /// </summary>
    public Task<ArticleResultDTO> GetArticle(int articleId)
        => QueryForObject<ArticleResultDTO>($"{nameof(ArticleMapper)}.GetArticle", new { articleId });

    /// <summary>
    /// 게시글을 추가한다.
    /// </summary>
    public Task<int> AddArticle(SaveArticleRequestDTO dto)
        => ExecuteScalar<int>($"{nameof(ArticleMapper)}.AddArticle", dto);

    /// <summary>
    /// 게시글을 수정한다.
    /// </summary>
    public Task<int> UpdateArticle(SaveArticleRequestDTO dto)
        => Execute($"{nameof(ArticleMapper)}.UpdateArticle", dto);

    /// <summary>
    /// 게시글을 삭제한다.
    /// </summary>
    public Task<int> RemoveArticle(int articleId, int? updaterId)
        => Execute($"{nameof(ArticleMapper)}.RemoveArticle", new { articleId, updaterId });
    #endregion

}
