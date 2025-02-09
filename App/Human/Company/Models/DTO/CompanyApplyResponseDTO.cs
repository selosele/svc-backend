namespace Svc.App.Human.Company.Models.DTO;

/// <summary>
/// 회사등록신청 응답 DTO
/// </summary>
public record CompanyApplyResponseDTO
{
    #region [필드]
    /// <summary>
    /// 회사등록신청
    /// </summary>
    public CompanyApplyResultDTO? CompanyApply { get; set; }

    /// <summary>
    /// 회사등록신청 목록
    /// </summary>
    public IList<CompanyApplyResultDTO>? CompanyApplyList { get; set; }
    #endregion
    
}
