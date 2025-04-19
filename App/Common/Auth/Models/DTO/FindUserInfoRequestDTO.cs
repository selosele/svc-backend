using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Auth.Models.DTO;

/// <summary>
/// 사용자 아이디/비밀번호 찾기 요청 DTO
/// </summary>
public record FindUserInfoRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 사용자 계정
    /// </summary>
    public string? UserAccount { get; set; }

    /// <summary>
    /// 직원명
    /// </summary>
    public string? EmployeeName { get; set; }

    /// <summary>
    /// 이메일주소
    /// </summary>
    public string? EmailAddr { get; set; }

    /// <summary>
    /// 본인인증 코드
    /// </summary>
    public string? CertCode { get; set; }

    /// <summary>
    /// 시스템관리자 권한으로 비밀번호 초기화 여부
    /// </summary>
    public string? ResetYn { get; set; }
    #endregion
    
}
