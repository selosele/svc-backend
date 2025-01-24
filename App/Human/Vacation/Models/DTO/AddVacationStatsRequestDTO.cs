using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가 통계 추가 요청 DTO
/// </summary>
public record AddVacationStatsRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }
    
    /// <summary>
    /// 직원 ID
    /// </summary>
    public int? EmployeeId { get; set; }
    #endregion

}
