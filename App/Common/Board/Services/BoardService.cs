using SmartSql.AOP;
using Svc.App.Common.Board.Mappers;
using Svc.App.Common.Board.Models.DTO;

namespace Svc.App.Common.Board.Services;

/// <summary>
/// 게시판 서비스 클래스
/// </summary>
public class BoardService
{
    #region [필드]
    private readonly BoardMapper _boardMapper;
    #endregion
    
    #region [생성자]
    public BoardService(
        BoardMapper boardMapper
    ) {
        _boardMapper = boardMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 게시판 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<BoardResponseDTO>> ListBoard()
        => await _boardMapper.ListBoard();

    /// <summary>
    /// 게시판을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<BoardResponseDTO> GetBoard(int boardId)
        => await _boardMapper.GetBoard(boardId);

    /// <summary>
    /// 게시판을 추가한다.
    /// </summary>
    [Transaction]
    public async Task<BoardResponseDTO> AddBoard(SaveBoardRequestDTO dto)
    {
        var boardId = await _boardMapper.AddBoard(dto);
        return await _boardMapper.GetBoard(boardId);
    }

    /// <summary>
    /// 게시판을 수정한다.
    /// </summary>
    [Transaction]
    public async Task<BoardResponseDTO> UpdateBoard(SaveBoardRequestDTO dto)
    {
        await _boardMapper.UpdateBoard(dto);
        return await _boardMapper.GetBoard(dto.BoardId);
    }

    /// <summary>
    /// 게시판을 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveBoard(int boardId, int? updaterId)
        => await _boardMapper.RemoveBoard(boardId, updaterId);
    #endregion
    
}

