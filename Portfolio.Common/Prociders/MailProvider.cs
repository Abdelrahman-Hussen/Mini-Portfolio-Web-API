using Microsoft.Extensions.Options;
using Portfolio.Common.Abstractions;
using Portfolio.Common.AppSettingsSections;
using System.Net;
using System.Net.Mail;

namespace Portfolio.Common.Provider
{
    internal class MailProvider(IOptionsMonitor<smtp> _smtpConfiguration) : IMailProvider
    {
        public async Task Send(string toEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient(_smtpConfiguration.CurrentValue.Host, _smtpConfiguration.CurrentValue.Port);

            var fromEmail = _smtpConfiguration.CurrentValue.Email;
            var fromPassword = _smtpConfiguration.CurrentValue.Password;

            var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
            };

            smtpClient.Credentials = new NetworkCredential(fromEmail, fromPassword);
            smtpClient.EnableSsl = true;
            await smtpClient.SendMailAsync(message);
        }
    }
}
