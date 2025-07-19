using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Common.Board.Models.DTO;

namespace Svc.App.Common.Board.Mappers;

/// <summary>
/// 게시판 매퍼
/// </summary>
public class BoardMapper(ISqlMapper sqlMapper) : MyMapperBase(sqlMapper)
{
    #region [메서드]
    /// <summary>
    /// 게시판 목록을 조회한다.
    /// </summary>
    public Task<IList<BoardResultDTO>> ListBoard(GetBoardRequestDTO? dto)
        => QueryForList<BoardResultDTO>($"{nameof(BoardMapper)}.ListBoard", dto);

    /// <summary>
    /// 메인화면 게시판 목록을 조회한다.
    /// </summary>
    public Task<IList<BoardResultDTO>> ListMainBoard(GetBoardRequestDTO? dto)
        => QueryForList<BoardResultDTO>($"{nameof(BoardMapper)}.ListMainBoard", dto);

    /// <summary>
    /// 게시판을 조회한다.
    /// </summary>
    public Task<BoardResultDTO> GetBoard(int? boardId)
        => QueryForObject<BoardResultDTO>($"{nameof(BoardMapper)}.GetBoard", new { boardId });

    /// <summary>
    /// 게시판을 추가한다.
    /// </summary>
    public Task<int> AddBoard(SaveBoardRequestDTO dto)
        => ExecuteScalar<int>($"{nameof(BoardMapper)}.AddBoard", dto);

    /// <summary>
    /// 게시판을 수정한다.
    /// </summary>
    public Task<int> UpdateBoard(SaveBoardRequestDTO dto)
        => Execute($"{nameof(BoardMapper)}.UpdateBoard", dto);

    /// <summary>
    /// 게시판을 삭제한다.
    /// </summary>
    public Task<int> RemoveBoard(int boardId, int? updaterId)
        => Execute($"{nameof(BoardMapper)}.RemoveBoard", new { boardId, updaterId });
    #endregion

}
