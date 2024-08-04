using System.ComponentModel.DataAnnotations;
using svc.App.Shared.Models.DTO;

namespace svc.App.Human.Employee.Models.DTO;

/// <summary>
/// 직원 수정 요청 DTO
/// </summary>
public record UpdateEmployeeRequestDTO : MyRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 직원 ID
    /// </summary>
    [Required]
    public int? EmployeeId { get; set; }

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
    #endregion

}
