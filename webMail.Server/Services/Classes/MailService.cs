using MailKit.Net.Smtp;
using webMail.Server.Schemas;
using webMail.Server.Services.Interfaces;

namespace webMail.Server.Services.Classes
{
    public class MailService(string login, string password, string host, int port) : IMailService
    {
        public async Task SendMessageAsync(SendMessageData messageData)
        {
            using var emailMessage = new MimeKit.MimeMessage();

            emailMessage.From.Add(new MimeKit.MailboxAddress("WebMail", login));
            emailMessage.To.Add(new MimeKit.MailboxAddress("", messageData.ToEmail));
            emailMessage.Subject = messageData.Subject;
            emailMessage.Body = new MimeKit.TextPart("Paint")
            {
                Text = messageData.Text
            };

            using var client = new SmtpClient();
            await client.ConnectAsync(host, port, true);
            await client.AuthenticateAsync(login, password);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
