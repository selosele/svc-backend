using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 아이디 찾기 요청 DTO
/// </summary>
public record FindUserAccountRequestDTO : HttpRequestDTOBase
{
    #region Fields
    /// <summary>
    /// 직원명
    /// </summary>
    public string? EmployeeName { get; set; }

    /// <summary>
    /// 이메일주소
    /// </summary>
    public string? EmailAddr { get; set; }
    #endregion
    
}
