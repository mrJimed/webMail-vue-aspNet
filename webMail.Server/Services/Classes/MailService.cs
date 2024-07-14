using MailKit.Net.Smtp;
using webMail.Server.Options;
using webMail.Server.Schemas;
using webMail.Server.Services.Interfaces;

namespace webMail.Server.Services.Classes
{
    public class MailService(MailOptions mailOptions) : IMailService
    {
        public async Task SendMessageAsync(SendMessageData messageData)
        {
            using var emailMessage = new MimeKit.MimeMessage();

            emailMessage.From.Add(new MimeKit.MailboxAddress("WebMail", mailOptions.Login));
            emailMessage.To.Add(new MimeKit.MailboxAddress("", messageData.ToEmail));
            emailMessage.Subject = messageData.Subject;
            emailMessage.Body = new MimeKit.TextPart("Paint")
            {
                Text = messageData.Text
            };

            using var client = new SmtpClient();
            await client.ConnectAsync(mailOptions.Host, mailOptions.Port, true);
            await client.AuthenticateAsync(mailOptions.Login, mailOptions.Password);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
