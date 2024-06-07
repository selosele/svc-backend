namespace svc.App.Shared.Models.Entities;

/// <summary>
/// Entity의 기본 클래스
/// </summary>
public class MyEntityBase
{
    /// <summary>
    /// 등록자 ID
    /// </summary>
    public int? CreaterId { get; set; }
    
    /// <summary>
    /// 등록일시
    /// </summary>
    public DateTime? CreateDt { get; set; }
    
    /// <summary>
    /// 수정자 ID
    /// </summary>
    public int? UpdaterId { get; set; }

    /// <summary>
    /// 수정일시
    /// </summary>
    public DateTime? UpdateDt { get; set; }

}
