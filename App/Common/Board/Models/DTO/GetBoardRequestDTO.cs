using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Board.Models.DTO;

/// <summary>
/// 게시판 조회 요청 DTO
/// </summary>
public record GetBoardRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 메인 화면 표출 여부
    /// </summary>
    public string? MainShowYn { get; set; }
    #endregion
}
