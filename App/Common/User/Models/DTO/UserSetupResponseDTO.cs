namespace Svc.App.Common.User.Models.DTO;

/// <summary>
/// 사용자 권한 응답 DTO
/// </summary>
public record UserSetupResponseDTO
{
    #region [필드]
    /// <summary>
    /// 사용자 설정
    /// </summary>
    public UserSetupResultDTO? UserSetup { get; set; }

    /// <summary>
    /// 사용자 설정 목록
    /// </summary>
    public IList<UserSetupResultDTO>? UserSetupList { get; set; }
    #endregion

}
