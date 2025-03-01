using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Human.Vacation.Models.DTO;

namespace Svc.App.Human.Vacation.Mappers;

/// <summary>
/// 휴가 계산 설정 매퍼 클래스
/// </summary>
public class VacationCalcMapper : MyMapperBase
{
    #region [생성자]
    public VacationCalcMapper(ISqlMapper sqlMapper) : base(sqlMapper) {}
    #endregion

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
