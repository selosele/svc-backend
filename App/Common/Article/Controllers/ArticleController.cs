using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Article.Models.DTO;
using Svc.App.Common.Article.Services;
using Svc.App.Common.Auth.Services;

namespace Svc.App.Common.Article.Controllers;

/// <summary>
/// 게시글 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/co/articles")]
public class ArticleController : ControllerBase
{
    #region [필드]
    private readonly AuthService _authService;
    private readonly ArticleService _articleService;
    #endregion
    
    #region [생성자]
    public ArticleController(
        AuthService authService,
        ArticleService articleService
    ) {
        _authService = authService;
        _articleService = articleService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 게시글 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<ArticleResponseDTO>>> ListArticle([FromQuery] GetArticleRequestDTO dto)
        => Ok(await _articleService.ListArticle(dto));
    #endregion

}
