namespace Svc.App.Shared.Models.Settings;

/// <summary>
/// SMTP 설정 클래스
/// </summary>
public record SmtpSettings
{
    #region Fields
    /// <summary>
    /// 서버명
    /// </summary>
    public string? Server { get; set; }

    /// <summary>
    /// 포트
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// 발신자 계정
    /// </summary>
    public string? FromId { get; set; }

    /// <summary>
    /// 발신자명
    /// </summary>
    public string? FromName { get; set; }

    /// <summary>
    /// 발신자 이메일주소
    /// </summary>
    public string? FromAddr { get; set; }

    /// <summary>
    /// 발신자 비밀번호
    /// </summary>
    public string? FromPw { get; set; }
    #endregion
}
