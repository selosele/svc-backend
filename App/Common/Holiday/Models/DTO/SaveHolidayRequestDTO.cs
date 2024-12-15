using System.ComponentModel.DataAnnotations;
using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Holiday.Models.DTO;

/// <summary>
/// 휴일 추가/수정 요청 DTO
/// </summary>
public record SaveHolidayRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 일자
    /// </summary>
    [MaxLength(8)]
    public string? YMD { get; set; }

    /// <summary>
    /// 기존 일자
    /// </summary>
    [MaxLength(8)]
    public string? OriginalYmd { get; set; }

    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 연도
    /// </summary>
    [MaxLength(4)]
    public string? YYYY { get; set; }

    /// <summary>
    /// 월
    /// </summary>
    [MaxLength(2)]
    public string? MM { get; set; }

    /// <summary>
    /// 일
    /// </summary>
    [MaxLength(2)]
    public string? DD { get; set; }

    /// <summary>
    /// 휴일명
    /// </summary>
    [MaxLength(30)]
    public string? HolidayName { get; set; }

    /// <summary>
    /// 휴일 내용
    /// </summary>
    [MaxLength(100)]
    public string? HolidayContent { get; set; }
    #endregion

}
