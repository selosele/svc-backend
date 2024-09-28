using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가 조회 요청 DTO
/// </summary>
public record GetVacationRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 휴가 ID
    /// </summary>
    public int? VacationId { get; set; }

    /// <summary>
    /// 근무이력 ID
    /// </summary>
    public int? WorkHistoryId { get; set; }

    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }
    #endregion

}
