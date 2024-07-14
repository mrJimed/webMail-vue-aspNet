using webMail.Server.Schemas;

namespace webMail.Server.Services.Interfaces
{
    public interface IMailService
    {
        Task SendMessageAsync(SendMessageData messageData);
    }
}
