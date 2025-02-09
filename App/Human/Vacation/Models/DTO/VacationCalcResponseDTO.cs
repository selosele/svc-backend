namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가 계산 설정 응답 DTO
/// </summary>
public record VacationCalcResponseDTO
{
    #region [필드]
    /// <summary>
    /// 휴가 계산 설정
    /// </summary>
    public VacationCalcResultDTO? VacationCalc { get; set; }

    /// <summary>
    /// 휴가 계산 설정 목록
    /// </summary>
    public IList<VacationCalcResultDTO>? VacationCalcList { get; set; }
    #endregion

}
