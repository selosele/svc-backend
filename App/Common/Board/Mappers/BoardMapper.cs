using SmartSql;
using Svc.App.Shared.Extensions;
using Svc.App.Common.Board.Models.DTO;

namespace Svc.App.Common.Board.Mappers;

/// <summary>
/// 게시판 매퍼 클래스
/// </summary>
public class BoardMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public BoardMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 게시판 목록을 조회한다.
    /// </summary>
    public Task<IList<BoardResultDTO>> ListBoard(GetBoardRequestDTO? dto)
        => SqlMapper.QueryForList<BoardResultDTO>($"{nameof(BoardMapper)}.ListBoard", dto);

    /// <summary>
    /// 메인화면 게시판 목록을 조회한다.
    /// </summary>
    public Task<IList<BoardResultDTO>> ListMainBoard(GetBoardRequestDTO? dto)
        => SqlMapper.QueryForList<BoardResultDTO>($"{nameof(BoardMapper)}.ListMainBoard", dto);

    /// <summary>
    /// 게시판을 조회한다.
    /// </summary>
    public Task<BoardResultDTO> GetBoard(int? boardId)
        => SqlMapper.QueryForObject<BoardResultDTO>($"{nameof(BoardMapper)}.GetBoard", new { boardId });

    /// <summary>
    /// 게시판을 추가한다.
    /// </summary>
    public Task<int> AddBoard(SaveBoardRequestDTO dto)
        => SqlMapper.ExecuteScalar<int>($"{nameof(BoardMapper)}.AddBoard", dto);

    /// <summary>
    /// 게시판을 수정한다.
    /// </summary>
    public Task<int> UpdateBoard(SaveBoardRequestDTO dto)
        => SqlMapper.Execute($"{nameof(BoardMapper)}.UpdateBoard", dto);

    /// <summary>
    /// 게시판을 삭제한다.
    /// </summary>
    public Task<int> RemoveBoard(int boardId, int? updaterId)
        => SqlMapper.Execute($"{nameof(BoardMapper)}.RemoveBoard", new { boardId, updaterId });
    #endregion

}
