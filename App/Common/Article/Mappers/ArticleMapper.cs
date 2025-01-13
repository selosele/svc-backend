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
    public Task<IList<ArticleResponseDTO>> ListArticle(GetArticleRequestDTO dto)
    {
        return SqlMapper.QueryAsync<ArticleResponseDTO>(new RequestContext
        {
            Scope = nameof(ArticleMapper),
            SqlId = "ListArticle",
            Request = dto
        });
    }
    #endregion

}
