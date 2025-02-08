using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Services;
using Svc.App.Common.Board.Models.DTO;
using Svc.App.Common.Board.Services;
using Svc.App.Shared.Utils;

namespace Svc.App.Common.Board.Controllers;

/// <summary>
/// 게시판 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/co/boards")]
public class BoardController : ControllerBase
{
    #region [필드]
    private readonly AuthService _authService;
    private readonly BoardService _boardService;
    #endregion
    
    #region [생성자]
    public BoardController(
        AuthService authService,
        BoardService boardService
    ) {
        _authService = authService;
        _boardService = boardService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 게시판 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<List<BoardResponseDTO>>> ListBoard([FromQuery] GetBoardRequestDTO? dto)
    {
        var boardList = await _boardService.ListBoard(dto);
        return Ok(new BoardResponseDTO { BoardList = boardList });
    }

    /// <summary>
    /// 메인화면 게시판 목록을 조회한다.
    /// </summary>
    [HttpGet("main")]
    [Authorize]
    public async Task<ActionResult<List<BoardResponseDTO>>> ListMainBoard([FromQuery] GetBoardRequestDTO? dto)
    {
        var boardList = await _boardService.ListMainBoard(dto);
        return Ok(new BoardResponseDTO { BoardList = boardList });
    }

    /// <summary>
    /// 게시판을 조회한다.
    /// </summary>
    [HttpGet("{boardId}")]
    public async Task<ActionResult<BoardResponseDTO>> GetBoard(int boardId)
    {
        var board = await _boardService.GetBoard(boardId);
        return Ok(new BoardResponseDTO { Board = board });
    }

    /// <summary>
    /// 게시판을 추가한다.
    /// </summary>
    [HttpPost]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<BoardResponseDTO>> AddBoard([FromBody] SaveBoardRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.CreaterId = user.UserId;

        var board = await _boardService.AddBoard(dto);
        return Created(string.Empty, new BoardResponseDTO { Board = board });
    }

    /// <summary>
    /// 게시판을 수정한다.
    /// </summary>
    [HttpPut("{boardId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<BoardResponseDTO>> UpdateBoard(int boardId, [FromBody] SaveBoardRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.UpdaterId = user.UserId;

        var board = await _boardService.UpdateBoard(dto);
        return Ok(new BoardResponseDTO { Board = board });
    }

    /// <summary>
    /// 게시판을 삭제한다.
    /// </summary>
    [HttpDelete("{boardId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult> RemoveBoard(int boardId)
    {
        var user = _authService.GetAuthenticatedUser();
        await _boardService.RemoveBoard(boardId, user.UserId);
        return NoContent();
    }
    #endregion

}
