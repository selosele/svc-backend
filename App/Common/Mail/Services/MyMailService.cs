using Microsoft.Extensions.Options;
using MimeKit;
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
    #endregion
    
    #region Constructor
    public MyMailService(
        ILogger<MyMailService> logger,
        IOptions<SmtpSettings> smtpSettings
    )
    {
        _logger = logger;
        _smtpSettings = smtpSettings.Value;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 메일을 발송한다.
    /// </summary>
    public async Task<bool> Send(SendMailDTO dto)
    {
        if (!dto.To!.Contains('@', StringComparison.CurrentCulture))
            return false;

        string id = dto.To.Split('@')[0];
        
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_smtpSettings.FromName, _smtpSettings.FromAddr));
        message.To.Add(new MailboxAddress(id, dto.To));
        message.Subject = dto.Subject;

        var builder = new BodyBuilder
        {
            HtmlBody = dto.Body
        };

        message.Body = builder.ToMessageBody();

        using var client = new MailKit.Net.Smtp.SmtpClient();
        try
        {
            await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_smtpSettings.FromId, _smtpSettings.FromPw);
            await client.SendAsync(message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
        finally
        {
            await client.DisconnectAsync(true);
        }

        return true;
    }
    #endregion
    
}

