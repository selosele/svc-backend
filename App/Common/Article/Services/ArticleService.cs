using SmartSql.AOP;
using Svc.App.Common.Article.Mappers;
using Svc.App.Common.Article.Models.DTO;

namespace Svc.App.Common.Article.Services;

/// <summary>
/// 게시글 서비스 클래스
/// </summary>
public class ArticleService
{
    #region [필드]
    private readonly ArticleMapper _articleMapper;
    #endregion
    
    #region [생성자]
    public ArticleService(
        ArticleMapper articleMapper
    ) {
        _articleMapper = articleMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 게시글 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<ArticleResultDTO>> ListArticle(GetArticleRequestDTO dto)
        => await _articleMapper.ListArticle(dto);

    /// <summary>
    /// 게시글을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<ArticleResultDTO> GetArticle(GetArticleRequestDTO dto)
        => await _articleMapper.GetArticle(dto);
        
    /// <summary>
    /// 게시글을 추가한다.
    /// </summary>
    [Transaction]
    public async Task<ArticleResultDTO> AddArticle(SaveArticleRequestDTO dto)
    {
        var articleId = await _articleMapper.AddArticle(dto);
        return await _articleMapper.GetArticle(new GetArticleRequestDTO { ArticleId = articleId });
    }
    #endregion
    
}

