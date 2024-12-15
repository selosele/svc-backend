using SmartSql.AOP;
using Svc.App.Human.Vacation.Mappers;
using Svc.App.Human.Vacation.Models.DTO;

namespace Svc.App.Human.Vacation.Services;

/// <summary>
/// 휴가 서비스 클래스
/// </summary>
public class VacationService
{
    #region [필드]
    private readonly VacationMapper _vacationMapper;
    private readonly VacationCalcMapper _vacationCalcMapper;
    #endregion
    
    #region [생성자]
    public VacationService(
        VacationMapper vacationMapper,
        VacationCalcMapper vacationCalcMapper
    )
    {
        _vacationMapper = vacationMapper;
        _vacationCalcMapper = vacationCalcMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 휴가 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<VacationResponseDTO>> ListVacation(GetVacationRequestDTO dto)
        => await _vacationMapper.ListVacation(dto);

    /// <summary>
    /// 휴가를 조회한다.
    /// </summary>
    [Transaction]
    public async Task<VacationResponseDTO> GetVacation(int vacationId)
        => await _vacationMapper.GetVacation(vacationId);

    /// <summary>
    /// 휴가를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<VacationResponseDTO> AddVacation(SaveVacationRequestDTO dto)
    {
        var vacationId = await _vacationMapper.AddVacation(dto);
        return await _vacationMapper.GetVacation(vacationId);
    }

    /// <summary>
    /// 휴가를 수정한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateVacation(SaveVacationRequestDTO dto)
        => await _vacationMapper.UpdateVacation(dto);

    /// <summary>
    /// 휴가를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveVacation(int vacationId, int? updaterId)
        => await _vacationMapper.RemoveVacation(vacationId, updaterId);

    /// <summary>
    /// 휴가 계산 설정 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<VacationCalcResponseDTO>> ListVacationCalc(int workHistoryId)
        => await _vacationCalcMapper.ListVacationCalc(workHistoryId);

    /// <summary>
    /// 휴가 계산 설정을 추가한다.
    /// </summary>
    [Transaction]
    public async Task<int> AddVacationCalc(AddVacationCalcRequestDTO dto)
    {
        // 모든 휴가 계산 설정을 삭제하고
        await _vacationCalcMapper.RemoveVacationCalc(dto.WorkHistoryId);

        // 다시 추가한다.
        return await _vacationCalcMapper.AddVacationCalc(dto);
    }
    #endregion
    
}

