using emailsender.Configuration;
using emailsender.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace emailsender.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }
        public async Task<EmailResult> SendEmailAsync(string destinatario, string assunto, string corpo, bool html = true)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(
                    _settings.Nome,
                    _settings.Remetente
                ));
                email.To.Add(MailboxAddress.Parse(destinatario));
                email.Subject = assunto;
                var body = new BodyBuilder();
                if (html)
                {
                    body.HtmlBody = corpo;
                } else {
                    body.TextBody = corpo;
                }
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(
                    _settings.Host,
                    _settings.Port,
                    SecureSocketOptions.StartTls
                );
                await smtp.AuthenticateAsync(
                    _settings.Usuario,
                    _settings.Senha
                );
                email.Body = body.ToMessageBody();
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
                return new EmailResult
                {
                    Resultado = true,
                    Mensagem = "SMTP efetuado."
                };
            }
            catch (Exception ex)
            {
                return new EmailResult
                {
                    Resultado = false,
                    Mensagem = $"Falha ao enviar {ex.Message}."
                };
            }
        }
    }
}