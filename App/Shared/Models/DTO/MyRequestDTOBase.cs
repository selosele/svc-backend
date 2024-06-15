namespace svc.App.Shared.Models.DTO;

/// <summary>
/// 요청 DTO의 기본 클래스
/// </summary>
public class MyRequestDTOBase
{
    /// <summary>
    /// 등록자 ID
    /// </summary>
    public int? CreaterId { get; set; }
    
    /// <summary>
    /// 수정자 ID
    /// </summary>
    public int? UpdaterId { get; set; }

    /// <summary>
    /// 수정일시
    /// </summary>
    public DateTime? UpdateDt { get; set; }

}
