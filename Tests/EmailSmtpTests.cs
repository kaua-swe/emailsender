using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Tests
{
    public class EmailSmtpTests
    {
        [Fact]
        public async Task AuthenticateSender()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<EmailSmtpTests>()
                .Build();

            var host = configuration["Email:Host"];
            var port = int.Parse(configuration["Email:Port"] ?? "587");
            var username = configuration["Email:Usuario"];
            var password = configuration["Email:Senha"];
            var remetente = configuration["Email:Remetente"];

            string destinatario = "email@teste.com";
            string assunto = "Teste de email";
            string corpo = "<h1>SMTP funcional</h1>";

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(
                username,
                remetente!
            ));
            email.To.Add(MailboxAddress.Parse(destinatario));
            email.Subject = assunto;

            var body = new BodyBuilder();
            body.HtmlBody = corpo;

            using var client = new SmtpClient();

            await client.ConnectAsync(host!, port, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(username!, password!);

            email.Body = body.ToMessageBody();
            await client.SendAsync(email);

            Assert.True(client.IsAuthenticated);

            await client.DisconnectAsync(true);
        }
    }
}