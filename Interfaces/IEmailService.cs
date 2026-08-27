using emailsender.Configuration;

namespace emailsender.Interfaces
{
    public interface IEmailService
    {
        Task<EmailResult> SendEmailAsync(string destinatario, string assunto, string corpo, bool html = true);
    }
}