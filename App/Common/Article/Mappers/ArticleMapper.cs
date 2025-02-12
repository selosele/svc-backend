using SmartSql;
using Svc.App.Shared.Extensions;
using Svc.App.Common.Article.Models.DTO;

namespace Svc.App.Common.Article.Mappers;

/// <summary>
/// 게시글 매퍼 클래스
/// </summary>
public class ArticleMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public ArticleMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 게시글 목록을 조회한다.
    /// </summary>
    public Task<IList<ArticleResultDTO>> ListArticle(GetArticleRequestDTO dto)
        => SqlMapper.QueryForList<ArticleResultDTO>(nameof(ArticleMapper), "ListArticle", dto);

    /// <summary>
    /// 이전/다음 게시글 목록을 조회한다.
    /// </summary>
    public Task<IList<ArticleResultDTO>> ListPrevNextArticle(GetArticleRequestDTO dto)
        => SqlMapper.QueryForList<ArticleResultDTO>(nameof(ArticleMapper), "ListPrevNextArticle", dto);

    /// <summary>
    /// 게시글을 조회한다.
    /// </summary>
    public Task<ArticleResultDTO> GetArticle(int articleId)
        => SqlMapper.QueryForObject<ArticleResultDTO>(nameof(ArticleMapper), "GetArticle", new { articleId });

    /// <summary>
    /// 게시글을 추가한다.
    /// </summary>
    public Task<int> AddArticle(SaveArticleRequestDTO dto)
        => SqlMapper.ExecuteScalar<int>(nameof(ArticleMapper), "AddArticle", dto);

    /// <summary>
    /// 게시글을 수정한다.
    /// </summary>
    public Task<int> UpdateArticle(SaveArticleRequestDTO dto)
        => SqlMapper.Execute(nameof(ArticleMapper), "UpdateArticle", dto);

    /// <summary>
    /// 게시글을 삭제한다.
    /// </summary>
    public Task<int> RemoveArticle(int articleId, int? updaterId)
        => SqlMapper.Execute(nameof(ArticleMapper), "RemoveArticle", new { articleId, updaterId });
    #endregion

}
