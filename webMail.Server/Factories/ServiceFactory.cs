using webMail.Server.Configuration;
using webMail.Server.Services.Classes;
using webMail.Server.Services.Interfaces;

namespace webMail.Server.Factories
{
    public static class ServiceFactory
    {
        public static IMailService CreateMailService(IServiceProvider serviceProvider)
        {
            var configuration = serviceProvider.GetService<IConfiguration>();
            var mailOptions = configuration.GetMailOptions();
            return new MailService(mailOptions);
        }
    }
}
