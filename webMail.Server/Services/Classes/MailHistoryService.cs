using webMail.Server.DbContexts;
using webMail.Server.Models;
using webMail.Server.Schemas;
using webMail.Server.Services.Interfaces;

namespace webMail.Server.Services.Classes
{
    public class MailHistoryService(WebMailDbContext dbContext) : IMailHistoryService
    {
        public void CreateMailHistory(SendMessageData messageData, User sender)
        {
            dbContext.MailHistories.Add(new MailHistory()
            {
                Subject = messageData.Subject,
                Text = messageData.Text,
                ToEmail = messageData.ToEmail,
                Sender = sender
            }
            );
            dbContext.SaveChanges();
        }

        public List<MailHistoryData> GetMailHistories(User sender)
        {
            return sender.MailHistories
                .OrderByDescending(mail => mail.CreateDt)
                .Select(mail => new MailHistoryData()
                {
                    Subject = mail.Subject,
                    Text = mail.Text,
                    ToEmail = mail.ToEmail,
                    CreateDt = mail.CreateDt.ToLocalTime()
                }).ToList();
        }
    }
}
