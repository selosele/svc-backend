namespace Svc.App.Common.Mail.Models.DTO;

/// <summary>
/// 메일 발송 DTO
/// </summary>
public record SendMailDTO
{
    #region Fields
    /// <summary>
    /// 수신자 메일 주소
    /// </summary>
    public string? To { get; set; }

    /// <summary>
    /// 메일 제목
    /// </summary>
    public string? Subject { get; set; }

    /// <summary>
    /// 메일 내용
    /// </summary>
    public string? Body { get; set; }
    #endregion
}
