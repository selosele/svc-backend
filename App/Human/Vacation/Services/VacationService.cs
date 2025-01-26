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
    private readonly VacationStatsMapper _vacationStatsMapper;
    #endregion
    
    #region [생성자]
    public VacationService(
        VacationMapper vacationMapper,
        VacationCalcMapper vacationCalcMapper,
        VacationStatsMapper vacationStatsMapper
    )
    {
        _vacationMapper = vacationMapper;
        _vacationCalcMapper = vacationCalcMapper;
        _vacationStatsMapper = vacationStatsMapper;
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
        // 1. 휴가를 추가한다.
        var vacationId = await _vacationMapper.AddVacation(dto);

        // 2. 모든 휴가 통계를 삭제하고
        await _vacationStatsMapper.RemoveVacationStats(dto.CreaterId);

        // 3. 휴가 통계를 추가한다.
        await _vacationStatsMapper.AddVacationStats(new AddVacationStatsRequestDTO { UserId = dto.CreaterId });

        // 4. 추가한 휴가를 조회해서 반환한다.
        return await _vacationMapper.GetVacation(vacationId);
    }

    /// <summary>
    /// 휴가를 수정한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateVacation(SaveVacationRequestDTO dto)
    {
        // 1. 휴가를 수정한다.
        var updateVacation = await _vacationMapper.UpdateVacation(dto);

        // 2. 모든 휴가 통계를 삭제하고
        await _vacationStatsMapper.RemoveVacationStats(dto.UpdaterId);

        // 3. 휴가 통계를 추가한다.
        await _vacationStatsMapper.AddVacationStats(new AddVacationStatsRequestDTO { UserId = dto.UpdaterId });

        return updateVacation;
    }

    /// <summary>
    /// 휴가를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveVacation(int vacationId, int? updaterId)
    {
        // 1. 휴가를 삭제한다.
        var removeVacation = await _vacationMapper.RemoveVacation(vacationId, updaterId);

        // 2. 모든 휴가 통계를 삭제하고
        await _vacationStatsMapper.RemoveVacationStats(updaterId);

        // 3. 휴가 통계를 추가한다.
        await _vacationStatsMapper.AddVacationStats(new AddVacationStatsRequestDTO { UserId = updaterId });

        return removeVacation;
    }

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

    /// <summary>
    /// 휴가 통계 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<VacationStatsResponseDTO>> ListVacationStats(GetVacationStatsRequestDTO dto)
        => await _vacationStatsMapper.ListVacationStats(dto);
    #endregion
    
}

