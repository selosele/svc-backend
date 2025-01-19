using SmartSql;
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
    {
        return SqlMapper.QueryAsync<ArticleResultDTO>(new RequestContext
        {
            Scope = nameof(ArticleMapper),
            SqlId = "ListArticle",
            Request = dto
        });
    }

    /// <summary>
    /// 이전/다음 게시글 목록을 조회한다.
    /// </summary>
    public Task<IList<ArticleResultDTO>> ListPrevNextArticle(GetArticleRequestDTO dto)
    {
        return SqlMapper.QueryAsync<ArticleResultDTO>(new RequestContext
        {
            Scope = nameof(ArticleMapper),
            SqlId = "ListPrevNextArticle",
            Request = dto
        });
    }

    /// <summary>
    /// 게시글을 조회한다.
    /// </summary>
    public Task<ArticleResultDTO> GetArticle(int articleId)
    {
        return SqlMapper.QuerySingleAsync<ArticleResultDTO>(new RequestContext
        {
            Scope = nameof(ArticleMapper),
            SqlId = "GetArticle",
            Request = new { articleId }
        });
    }

    /// <summary>
    /// 게시글을 추가한다.
    /// </summary>
    public Task<int> AddArticle(SaveArticleRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<int>(new RequestContext
        {
            Scope = nameof(ArticleMapper),
            SqlId = "AddArticle",
            Request = dto
        });
    }

    /// <summary>
    /// 게시글을 삭제한다.
    /// </summary>
    public Task<int> RemoveArticle(int articleId, int? updaterId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(ArticleMapper),
            SqlId = "RemoveArticle",
            Request = new { articleId, updaterId }
        });
    }
    #endregion

}
