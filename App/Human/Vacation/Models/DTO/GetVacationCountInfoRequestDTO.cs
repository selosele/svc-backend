using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Vacation.Models.DTO;

/// <summary>
/// 휴가일수정보 조회 요청 DTO
/// </summary>
public record GetVacationCountInfoRequestDTO : HttpRequestDTOBase
{
    #region [필드]
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
