using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Board.Models.DTO;

/// <summary>
/// 게시판 추가/수정 요청 DTO
/// </summary>
public record SaveBoardRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 게시판 ID
    /// </summary>
    public int? BoardId { get; set; }

    /// <summary>
    /// 게시판명
    /// </summary>
    public string? BoardName { get; set; }
    
    /// <summary>
    /// 게시판 내용
    /// </summary>
    public string? BoardContent { get; set; }
    
    /// <summary>
    /// 게시판 구분 코드
    /// </summary>
    public string? BoardTypeCode { get; set; }
    #endregion
}
