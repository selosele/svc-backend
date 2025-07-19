using SmartSql.AOP;
using Svc.App.Common.Board.Mappers;
using Svc.App.Common.Board.Models.DTO;

namespace Svc.App.Common.Board.Services;

/// <summary>
/// 게시판 서비스
/// </summary>
public class BoardService(BoardMapper boardMapper)
{
    #region [필드]
    private readonly BoardMapper _boardMapper = boardMapper;
    #endregion

    #region [메서드]
    /// <summary>
    /// 게시판 목록을 조회한다.
    /// </summary>
    public async Task<IList<BoardResultDTO>> ListBoard(GetBoardRequestDTO? dto)
        => await _boardMapper.ListBoard(dto);

    /// <summary>
    /// 메인화면 게시판 목록을 조회한다.
    /// </summary>
    public async Task<IList<BoardResultDTO>> ListMainBoard(GetBoardRequestDTO? dto)
        => await _boardMapper.ListMainBoard(dto);

    /// <summary>
    /// 게시판을 조회한다.
    /// </summary>
    public async Task<BoardResultDTO> GetBoard(int? boardId)
        => await _boardMapper.GetBoard(boardId);

    /// <summary>
    /// 게시판을 추가한다.
    /// </summary>
    [Transaction]
    public async Task<BoardResultDTO> AddBoard(SaveBoardRequestDTO dto)
    {
        var boardId = await _boardMapper.AddBoard(dto);
        return await _boardMapper.GetBoard(boardId);
    }

    /// <summary>
    /// 게시판을 수정한다.
    /// </summary>
    [Transaction]
    public async Task<BoardResultDTO> UpdateBoard(SaveBoardRequestDTO dto)
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

