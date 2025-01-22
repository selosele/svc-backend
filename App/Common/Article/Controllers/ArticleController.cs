using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Article.Models.DTO;
using Svc.App.Common.Article.Services;
using Svc.App.Common.Auth.Services;
using Svc.App.Common.Board.Services;
using Svc.App.Shared.Exceptions;
using Svc.App.Shared.Utils;

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
    private readonly BoardService _boardService;
    #endregion
    
    #region [생성자]
    public ArticleController(
        AuthService authService,
        ArticleService articleService,
        BoardService boardService
    ) {
        _authService = authService;
        _articleService = articleService;
        _boardService = boardService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 게시글 목록을 조회한다.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<ArticleResponseDTO>>> ListArticle([FromQuery] GetArticleRequestDTO dto)
    {
        var board = await _boardService.GetBoard(dto.BoardId);

        // 미사용 게시판은 접속 불가하도록 처리
        if (board.UseYn == "N")
            throw new BizException("사용 중지된 게시판이에요. 시스템관리자에게 문의해주세요.");

        // 비로그인 유저는 공지사항 게시판 제외 접속 불가하도록 처리
        if (!_authService.IsLogined() && board.BoardTypeCode == "NORMAL")
            return NotFound();

        var articleList = await _articleService.ListArticle(dto);

        return Ok(new ArticleResponseDTO { Board = board, ArticleList = articleList });
    }

    /// <summary>
    /// 게시글을 조회한다.
    /// </summary>
    [HttpGet("{articleId}")]
    public async Task<ActionResult<ArticleResponseDTO>> GetArticle(int articleId)
    {
        var article = await _articleService.GetArticle(articleId);

        var board = await _boardService.GetBoard(article.BoardId);
        if (board.UseYn == "N") // 미사용 게시판은 접속 불가하도록 처리
            throw new BizException("사용 중지된 게시판이에요. 시스템관리자에게 문의해주세요.");

        // 비로그인 유저는 공지사항 게시판 제외 접속 불가하도록 처리
        if (!_authService.IsLogined() && board.BoardTypeCode == "NORMAL")
            return NotFound();

        var prevNextArticleList = await _articleService.ListPrevNextArticle(new GetArticleRequestDTO
        {
            ArticleId = articleId,
            BoardId = board.BoardId
        });

        return Ok(new ArticleResponseDTO { Article = article, ArticleList = prevNextArticleList, Board = board });
    }

    /// <summary>
    /// 게시글을 추가한다.
    /// </summary>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ArticleResponseDTO>> AddArticle([FromBody] SaveArticleRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.CreaterId = user.UserId;
        dto.ArticleWriterId = user.UserId;

        var board = await _boardService.GetBoard(dto.BoardId);

        // 일반 유저는 공지사항 게시판 입력 불가
        if (!_authService.HasRole(RoleUtil.SYSTEM_ADMIN) && board.BoardTypeCode == "NOTICE")
            return NotFound();

        var article = await _articleService.AddArticle(dto);

        return Created(string.Empty, new ArticleResponseDTO { Board = board, Article = article });
    }

    /// <summary>
    /// 게시글을 수정한다.
    /// </summary>
    [HttpPut("{articleId}")]
    [Authorize]
    public async Task<ActionResult<int>> UpdateArticle(int articleId, [FromBody] SaveArticleRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.UpdaterId = user.UserId;

        // 작성자는 본인이 작성한 글만 수정 가능
        if (dto.ArticleWriterId != user.UserId)
            return NotFound();

        var board = await _boardService.GetBoard(dto.BoardId);

        // 일반 유저는 공지사항 게시판 입력 불가
        if (!_authService.HasRole(RoleUtil.SYSTEM_ADMIN) && board.BoardTypeCode == "NOTICE")
            return NotFound();

        return Ok(await _articleService.UpdateArticle(dto));
    }

    /// <summary>
    /// 게시글을 삭제한다.
    /// </summary>
    [HttpDelete("{articleId}")]
    [Authorize]
    public async Task<ActionResult> RemoveArticle(int articleId)
    {
        var user = _authService.GetAuthenticatedUser();
        var article = await _articleService.GetArticle(articleId);

        // 일반 유저는 공지사항 게시판 입력 불가
        if (!_authService.HasRole(RoleUtil.SYSTEM_ADMIN) && article.BoardTypeCode == "NOTICE")
            return NotFound();

        // 작성자는 본인이 작성한 글만 삭제 가능 and 시스템관리자는 모든 글을 삭제 가능
        if (article.ArticleWriterId != user.UserId && !_authService.HasRole(RoleUtil.SYSTEM_ADMIN))
            return NotFound();

        await _articleService.RemoveArticle(articleId, user.UserId);
        return NoContent();
    }
    #endregion

}
