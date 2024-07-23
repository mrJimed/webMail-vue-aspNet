using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webMail.Server.Schemas;
using webMail.Server.Services.Interfaces;

namespace webMail.Server.Controllers
{
    [Route("mail")]
    [Authorize]
    [ApiController]
    public class MailController(IMailService mailService, IMailHistoryService mailHistoryService, IUserService userService) : ControllerBase
    {
        [HttpPost("send")]
        public async Task SendMessage(SendMessageData messageData)
        {
            await mailService.SendMessageAsync(messageData);
            var sender = userService.GetUser(User.Identity.Name);
            mailHistoryService.CreateMailHistory(messageData, sender);
        }

        [HttpGet("history")]
        public List<MailHistoryData> GetMailHistories()
        {
            var sender = userService.GetUser(User.Identity.Name);
            return mailHistoryService.GetMailHistories(sender);
        }
    }
}
