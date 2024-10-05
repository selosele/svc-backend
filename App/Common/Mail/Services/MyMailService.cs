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
        message.Subject = dto.Subject!.Trim();

        var builder = new BodyBuilder
        {
            HtmlBody = dto.Body!.Trim()
        };

        message.Body = builder.ToMessageBody();

        try
        {
            // SMTP 클라이언트 연결 및 인증 상태 확인 후 연결
            if (!_client.IsConnected || !_client.IsAuthenticated)
            {
                await _client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await _client.AuthenticateAsync(_smtpSettings.FromId, _smtpSettings.FromPw);
            }
            await _client.SendAsync(message);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send email to {Email}. Server: {Server}, Port: {Port}", dto.To, _smtpSettings.Server, _smtpSettings.Port);
            return false;
        }
        finally
        {
            await _client.DisconnectAsync(true);
        }
    }

    /// <summary>
    /// 이메일 유효성을 검증한다.
    /// </summary>
    private static bool IsValidEmail(string email)
        => MailboxAddress.TryParse(email, out _);
    #endregion
    
}

