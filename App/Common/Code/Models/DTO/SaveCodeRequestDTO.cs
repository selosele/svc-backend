using Svc.App.Shared.Models.DTO;

namespace Svc.App.Common.Code.Models.DTO;

/// <summary>
/// 코드 추가/수정 요청 DTO
/// </summary>
public record SaveCodeRequestDTO : HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 기존 코드 ID
    /// </summary>
    public string? OriginalCodeId { get; set; }

    /// <summary>
    /// 코드 ID
    /// </summary>
    public string? CodeId { get; set; }

    /// <summary>
    /// 상위 코드 ID
    /// </summary>
    public string? UpCodeId { get; set; }
    
    /// <summary>
    /// 코드 값
    /// </summary>
    public string? CodeValue { get; set; }
    
    /// <summary>
    /// 코드 명
    /// </summary>
    public string? CodeName { get; set; }
    
    /// <summary>
    /// 코드 내용
    /// </summary>
    public string? CodeContent { get; set; }
    
    /// <summary>
    /// 코드 순서
    /// </summary>
    public int? CodeOrder { get; set; }
    
    /// <summary>
    /// 코드 뎁스
    /// </summary>
    public int? CodeDepth { get; set; }

    /// <summary>
    /// 사용자 ID
    /// </summary>
    public int? UserId { get; set; }
    #endregion
}
