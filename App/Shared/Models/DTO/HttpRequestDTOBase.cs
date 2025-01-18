namespace Svc.App.Shared.Models.DTO;

/// <summary>
/// HTTP 요청 DTO의 기본 클래스
/// </summary>
public record HttpRequestDTOBase
{
    #region [필드]
    /// <summary>
    /// 사용 여부
    /// </summary>
    public string? UseYn { get; set; }

    /// <summary>
    /// 삭제 여부
    /// </summary>
    public string? DeleteYn { get; set; } = "N";

    /// <summary>
    /// 등록자 ID
    /// </summary>
    public int? CreaterId { get; set; }
    
    /// <summary>
    /// 수정자 ID
    /// </summary>
    public int? UpdaterId { get; set; }
    #endregion
    
}
