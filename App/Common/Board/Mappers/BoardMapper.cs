using SmartSql;
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
    public Task<IList<BoardResponseDTO>> ListBoard()
    {
        return SqlMapper.QueryAsync<BoardResponseDTO>(new RequestContext
        {
            Scope = nameof(BoardMapper),
            SqlId = "ListBoard"
        });
    }

    /// <summary>
    /// 게시판을 조회한다.
    /// </summary>
    public Task<BoardResponseDTO> GetBoard(int? boardId)
    {
        return SqlMapper.QuerySingleAsync<BoardResponseDTO>(new RequestContext
        {
            Scope = nameof(BoardMapper),
            SqlId = "GetBoard",
            Request = new { boardId }
        });
    }

    /// <summary>
    /// 게시판을 추가한다.
    /// </summary>
    public Task<int> AddBoard(SaveBoardRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<int>(new RequestContext
        {
            Scope = nameof(BoardMapper),
            SqlId = "AddBoard",
            Request = dto
        });
    }

    /// <summary>
    /// 게시판을 수정한다.
    /// </summary>
    public Task<int> UpdateBoard(SaveBoardRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(BoardMapper),
            SqlId = "UpdateBoard",
            Request = dto
        });
    }

    /// <summary>
    /// 게시판을 삭제한다.
    /// </summary>
    public Task<int> RemoveBoard(int boardId, int? updaterId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(BoardMapper),
            SqlId = "RemoveBoard",
            Request = new { boardId, updaterId }
        });
    }
    #endregion

}
