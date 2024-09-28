using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Holiday.Models.DTO;

/// <summary>
/// 휴일 조회 요청 DTO
/// </summary>
public record GetHolidayRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 일자
    /// </summary>
    public string? YMD { get; set; }

    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 연도
    /// </summary>
    public string? YYYY { get; set; }

    /// <summary>
    /// 월
    /// </summary>
    public string? MM { get; set; }

    /// <summary>
    /// 일
    /// </summary>
    public string? DD { get; set; }
    #endregion

}
