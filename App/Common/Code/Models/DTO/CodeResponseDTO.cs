namespace Svc.App.Common.Code.Models.DTO;

/// <summary>
/// 코드 응답 DTO
/// </summary>
public record CodeResponseDTO
{
    #region [필드]
    /// <summary>
    /// 코드
    /// </summary>
    public CodeResultDTO? Code { get; set; }
    
    /// <summary>
    /// 코드 목록
    /// </summary>
    public IList<CodeResultDTO>? CodeList { get; set; }
    #endregion
    
}
