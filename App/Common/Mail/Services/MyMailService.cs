using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using Svc.App.Common.Mail.Models.DTO;
using Svc.App.Shared.Models.Settings;

namespace Svc.App.Common.Mail.Services;

/// <summary>
/// 메일 서비스 클래스
/// </summary>
public class MyMailService
{
    #region Fields
    private readonly ILogger _logger;
    private readonly SmtpSettings _smtpSettings;
    private readonly SmtpClient _client;
    #endregion
    
    #region Constructor
    public MyMailService(
        ILogger<MyMailService> logger,
        IOptions<SmtpSettings> smtpSettings
    )
    {
        _logger = logger;
        _smtpSettings = smtpSettings.Value;
        _client = new SmtpClient(); // SMTP 클라이언트 인스턴스 생성
    }
    #endregion

    #region Methods
    /// <summary>
    /// 메일을 발송한다.
    /// </summary>
    public async Task<bool> Send(SendMailDTO dto)
    {
        if (!IsValidEmail(dto.To!))
            return false;

        var id = dto.To!.Split('@')[0];
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_smtpSettings.FromName, _smtpSettings.FromAddr));
        message.To.Add(new MailboxAddress(id, dto.To));
        message.Subject = dto.Subject;

        var builder = new BodyBuilder
        {
            HtmlBody = dto.Body
        };

        message.Body = builder.ToMessageBody();

        try
        {
            await _client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await _client.AuthenticateAsync(_smtpSettings.FromId, _smtpSettings.FromPw);
            await _client.SendAsync(message);
            await _client.DisconnectAsync(true);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send email to {Email}", dto.To);
            await _client.DisconnectAsync(true);
            return false;
        }
    }

    /// <summary>
    /// 이메일 유효성을 검증한다.
    /// </summary>
    private static bool IsValidEmail(string email)
    {
        if (!email.Contains('@', StringComparison.CurrentCulture))
            return false;

        try
        {
            var id = email.Split('@')[0];
            var address = new MailboxAddress(id, email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    #endregion
    
}

