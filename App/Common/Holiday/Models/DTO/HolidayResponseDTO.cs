namespace Svc.App.Common.Holiday.Models.DTO;

/// <summary>
/// 휴일 응답 DTO
/// </summary>
public record HolidayResponseDTO
{
    #region [필드]
    /// <summary>
    /// 휴일
    /// </summary>
    public HolidayResultDTO? Holiday { get; set; }

    /// <summary>
    /// 휴일 목록
    /// </summary>
    public IList<HolidayResultDTO>? HolidayList { get; set; }
    #endregion
    
}
