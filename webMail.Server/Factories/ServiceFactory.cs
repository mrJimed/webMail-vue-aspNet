using webMail.Server.Services.Classes;
using webMail.Server.Services.Interfaces;

namespace webMail.Server.Factories
{
    public static class ServiceFactory
    {
        public static IMailService CreateMailService(IServiceProvider serviceProvider)
        {
            const string MAIL_SERVICE_ROOT_KEY = "MAIL";
            IConfiguration configuration = serviceProvider.GetService<IConfiguration>();

            var host = configuration.GetSection($"{MAIL_SERVICE_ROOT_KEY}:Host").Value;
            var port = int.Parse(configuration.GetSection($"{MAIL_SERVICE_ROOT_KEY}:Port").Value);
            var login = configuration.GetSection($"{MAIL_SERVICE_ROOT_KEY}:Login").Value;
            var password = configuration.GetSection($"{MAIL_SERVICE_ROOT_KEY}:Password").Value;

            return new MailService(login, password, host, port);
        }
    }
}
