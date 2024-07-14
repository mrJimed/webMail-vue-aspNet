using Microsoft.AspNetCore.Mvc;
using webMail.Server.Schemas;
using webMail.Server.Services.Interfaces;

namespace webMail.Server.Controllers
{
    [Route("mail")]
    [ApiController]
    public class MailController(IMailService mailService) : ControllerBase
    {
        [HttpPost("send")]
        public async Task SendMessage(SendMessageData messageData)
        {
            await mailService.SendMessageAsync(messageData);
        }
    }
}
