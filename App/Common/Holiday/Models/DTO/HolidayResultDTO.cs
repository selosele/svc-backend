namespace Svc.App.Common.Holiday.Models.DTO;

/// <summary>
/// 휴일 조회 결과 DTO
/// </summary>
public record HolidayResultDTO
{
    #region [필드]
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
    
    /// <summary>
    /// 휴일명
    /// </summary>
    public string? HolidayName { get; set; }
    
    /// <summary>
    /// 휴일 내용
    /// </summary>
    public string? HolidayContent { get; set; }
    
    /// <summary>
    /// 사용 여부
    /// </summary>
    public string? UseYn { get; set; }
    #endregion
    
}
