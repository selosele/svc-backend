using System.ComponentModel.DataAnnotations;
using Svc.App.Shared.Models.DTO;

namespace Svc.App.Human.Employee.Models.DTO;

/// <summary>
/// 직원 추가 요청 DTO
/// </summary>
public record AddEmployeeRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 직원명
    /// </summary>
    [Required]
    [MaxLength(30)]
    public string? EmployeeName { get; set; }

    /// <summary>
    /// 성별 코드
    /// </summary>
    [Required]
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
    /// 근무이력 정보
    /// </summary>
    public SaveWorkHistoryRequestDTO? WorkHistory { get; set; }
    #endregion

}