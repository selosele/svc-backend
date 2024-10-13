namespace Svc.App.Human.Employee.Models.DTO;

/// <summary>
/// 근무이력 응답 DTO
/// </summary>
public record WorkHistoryResponseDTO
{
    #region Fields
    /// <summary>
    /// 근무이력 ID
    /// </summary>
    public int? WorkHistoryId { get; set; }

    /// <summary>
    /// 회사 ID
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// 법인명
    /// </summary>
    public string? CorporateName { get; set; }

    /// <summary>
    /// 회사명
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// 직위 코드
    /// </summary>
    public string? RankCode { get; set; }

    /// <summary>
    /// 직위 코드명
    /// </summary>
    public string? RankCodeName { get; set; }

    /// <summary>
    /// 직책 코드
    /// </summary>
    public string? JobTitleCode { get; set; }

    /// <summary>
    /// 직책 코드명
    /// </summary>
    public string? JobTitleCodeName { get; set; }

    /// <summary>
    /// 연차발생기준 코드
    /// </summary>
    public string? AnnualTypeCode { get; set; }

    /// <summary>
    /// 입사일자
    /// </summary>
    public string? JoinYmd { get; set; }

    /// <summary>
    /// 퇴사일자
    /// </summary>
    public string? QuitYmd { get; set; }

    /// <summary>
    /// 재직기간(년도)
    /// </summary>
    public int? WorkDiffY { get; set; }

    /// <summary>
    /// 재직기간(월)
    /// </summary>
    public int? WorkDiffM { get; set; }

    /// <summary>
    /// 휴가 사용일수
    /// </summary>
    public double? VacationUseCount { get; set; }

    /// <summary>
    /// 잔여 휴가 개수
    /// </summary>
    public double? VacationRemainCount { get; set; }
    #endregion

}
