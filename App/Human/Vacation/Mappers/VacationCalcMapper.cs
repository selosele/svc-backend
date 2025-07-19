using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Human.Vacation.Models.DTO;

namespace Svc.App.Human.Vacation.Mappers;

/// <summary>
/// 휴가 계산 설정 매퍼
/// </summary>
public class VacationCalcMapper(ISqlMapper sqlMapper) : MyMapperBase(sqlMapper)
{
    #region [메서드]
    /// <summary>
    /// 휴가 계산 설정 목록을 조회한다.
    /// </summary>
    public Task<IList<VacationCalcResultDTO>> ListVacationCalc(int? workHistoryId)
        => QueryForList<VacationCalcResultDTO>($"{nameof(VacationCalcMapper)}.ListVacationCalc", new { workHistoryId });

    /// <summary>
    /// 휴가 계산 설정을 추가한다.
    /// </summary>
    public Task<int> AddVacationCalc(AddVacationCalcRequestDTO dto)
        => Execute($"{nameof(VacationCalcMapper)}.AddVacationCalc", new { DTO = dto });

    /// <summary>
    /// 휴가 계산 설정을 삭제한다.
    /// </summary>
    public Task<int> RemoveVacationCalc(int? workHistoryId)
        => Execute($"{nameof(VacationCalcMapper)}.RemoveVacationCalc", new { workHistoryId });
    #endregion

}
