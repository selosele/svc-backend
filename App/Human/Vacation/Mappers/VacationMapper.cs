using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Human.Vacation.Models.DTO;

namespace Svc.App.Human.Vacation.Mappers;

/// <summary>
/// 휴가 매퍼
/// </summary>
public class VacationMapper(ISqlMapper sqlMapper) : MyMapperBase(sqlMapper)
{
    #region [메서드]
    /// <summary>
    /// 휴가 목록을 조회한다.
    /// </summary>
    public Task<IList<VacationResultDTO>> ListVacation(GetVacationRequestDTO dto)
        => QueryForList<VacationResultDTO>($"{nameof(VacationMapper)}.ListVacation", dto);

    /// <summary>
    /// 휴가를 조회한다.
    /// </summary>
    public Task<VacationResultDTO> GetVacation(int vacationId)
        => QueryForObject<VacationResultDTO>($"{nameof(VacationMapper)}.GetVacation", new { vacationId });

    /// <summary>
    /// 휴가를 추가한다.
    /// </summary>
    public Task<int> AddVacation(SaveVacationRequestDTO dto)
        => ExecuteScalar<int>($"{nameof(VacationMapper)}.AddVacation", dto);

    /// <summary>
    /// 휴가를 수정한다.
    /// </summary>
    public Task<int> UpdateVacation(SaveVacationRequestDTO dto)
        => Execute($"{nameof(VacationMapper)}.UpdateVacation", dto);

    /// <summary>
    /// 휴가를 삭제한다.
    /// </summary>
    public Task<int> RemoveVacation(int vacationId, int? updaterId)
        => Execute($"{nameof(VacationMapper)}.RemoveVacation", new { vacationId, updaterId });

    /// <summary>
    /// 휴가일수정보를 조회한다.
    /// </summary>
    public Task<VacationCountInfoResultDTO> GetVacationCountInfo(GetVacationCountInfoRequestDTO dto)
        => QueryForObject<VacationCountInfoResultDTO>($"{nameof(VacationMapper)}.GetVacationCountInfo", dto);

    /// <summary>
    /// 월별 휴가사용일수 목록을 조회한다.
    /// </summary>
    public Task<IList<VacationByMonthResultDTO>> ListVacationByMonth(GetVacationByMonthRequestDTO dto)
        => QueryForList<VacationByMonthResultDTO>($"{nameof(VacationMapper)}.ListVacationByMonth", dto);
    #endregion

}
