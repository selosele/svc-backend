namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가 응답 DTO
/// </summary>
public record VacationResponseDTO
{
    #region [필드]
    /// <summary>
    /// 휴가
    /// </summary>
    public VacationResultDTO? Vacation { get; set; }

    /// <summary>
    /// 휴가 목록
    /// </summary>
    public IList<VacationResultDTO>? VacationList { get; set; }
    #endregion

}
