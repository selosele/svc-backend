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

    /// <summary>
    /// 게시판 순서
    /// </summary>
    public int? BoardOrder { get; set; }
    
    /// <summary>
    /// 메인 화면 표출 여부
    /// </summary>
    public string? MainShowYn { get; set; }
    #endregion
}
