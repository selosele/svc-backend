namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 본인인증 이력 응답 DTO
/// </summary>
public record UserCertHistoryResponseDTO
{
    #region [필드]
    /// <summary>
    /// 본인인증 이력
    /// </summary>
    public UserCertHistoryResultDTO? UserCertHistory { get; set; }

    /// <summary>
    /// 본인인증 이력 목록
    /// </summary>
    public IList<UserCertHistoryResultDTO>? UserCertHistoryList { get; set; }
    #endregion
    
}
