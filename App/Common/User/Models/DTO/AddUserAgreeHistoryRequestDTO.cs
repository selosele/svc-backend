using System.ComponentModel.DataAnnotations;
using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 동의 이력 추가 요청 DTO
/// </summary>
public record AddUserAgreeHistoryRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// 사용자 계정
    /// </summary>
    [MaxLength(20)]
    public string? UserAccount { get; set; }

    /// <summary>
    /// 동의 구분 코드
    /// </summary>
    public string? AgreeTypeCode { get; set; }

    /// <summary>
    /// 동의 여부
    /// </summary>
    public string? AgreeYn { get; set; }
    #endregion

}
