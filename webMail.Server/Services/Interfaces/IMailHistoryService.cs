using webMail.Server.Models;
using webMail.Server.Schemas;

namespace webMail.Server.Services.Interfaces
{
    public interface IMailHistoryService
    {
        void CreateMailHistory(SendMessageData messageData, User sender);
        List<MailHistoryData> GetMailHistories(User sender);
    }
}
