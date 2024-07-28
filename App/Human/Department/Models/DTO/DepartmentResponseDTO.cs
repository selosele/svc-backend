namespace svc.App.Human.Department.Models.DTO;

/// <summary>
/// 부서 응답 DTO
/// </summary>
public record DepartmentResponseDTO
{
    #region Fields
    /// <summary>
    /// 부서 ID
    /// </summary>
    public int? DepartmentId { get; set; }

    /// <summary>
    /// 회사 ID
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// 상위 부서 ID
    /// </summary>
    public int? UpDepartmentId { get; set; }
    
    /// <summary>
    /// 부서 명
    /// </summary>
    public string? DepartmentName { get; set; }

    /// <summary>
    /// 부서 순서
    /// </summary>
    public int? DepartmentOrder { get; set; }

    /// <summary>
    /// 직급 코드
    /// </summary>
    public string? RankCode { get; set; }

    /// <summary>
    /// 직책 코드
    /// </summary>
    public string? JobTitleCode { get; set; }
    #endregion

}
