using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Employee.Models.DTO;

/// <summary>
/// 직원 회사 추가/수정 요청 DTO
/// </summary>
public record SaveEmployeeCompanyRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 직원 회사 ID
    /// </summary>
    public int? EmployeeCompanyId { get; set; }

    /// <summary>
    /// 직원 ID
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// 회사 ID
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// 직위 코드
    /// </summary>
    public string? RankCode { get; set; }

    /// <summary>
    /// 직책 코드
    /// </summary>
    public string? JobTitleCode { get; set; }

    /// <summary>
    /// 입사일자
    /// </summary>
    public string? JoinYmd { get; set; }

    /// <summary>
    /// 퇴사일자
    /// </summary>
    public string? QuitYmd { get; set; }
    #endregion

}
