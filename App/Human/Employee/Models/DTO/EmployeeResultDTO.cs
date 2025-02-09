namespace Svc.App.Human.Employee.Models.DTO;

/// <summary>
/// 직원 조회 결과 DTO
/// </summary>
public record EmployeeResultDTO
{
    #region [필드]
    /// <summary>
    /// 직원 ID
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 직원명
    /// </summary>
    public string? EmployeeName { get; set; }
    
    /// <summary>
    /// 성별 코드
    /// </summary>
    public string? GenderCode { get; set; }
    
    /// <summary>
    /// 생년월일
    /// </summary>
    public string? BirthYmd { get; set; }
    
    /// <summary>
    /// 휴대폰번호
    /// </summary>
    public string? PhoneNo { get; set; }

    /// <summary>
    /// 이메일주소
    /// </summary>
    public string? EmailAddr { get; set; }
    
    /// <summary>
    /// 사용자 마지막 로그인 일시
    /// </summary>
    public string? LastLoginDt { get; set; }

    /// <summary>
    /// 근무이력 목록
    /// </summary>
    public IList<WorkHistoryResultDTO>? WorkHistoryList { get; set; } = [];
    #endregion

}
