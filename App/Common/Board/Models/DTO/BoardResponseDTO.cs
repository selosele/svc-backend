namespace Svc.App.Common.Board.Models.DTO;

/// <summary>
/// 게시판 응답 DTO
/// </summary>
public record BoardResponseDTO
{
    #region [필드]
    /// <summary>
    /// 게시판
    /// </summary>
    public BoardResultDTO? Board { get; set; }
    
    /// <summary>
    /// 게시판 목록
    /// </summary>
    public IList<BoardResultDTO>? BoardList { get; set; }
    #endregion
    
}
