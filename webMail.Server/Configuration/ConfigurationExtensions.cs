using webMail.Server.Options;

namespace webMail.Server.Configuration
{
    public static class ConfigurationExtensions
    {
        public static MailOptions GetMailOptions(this IConfiguration configuration)
        {
            var mailOptions = new MailOptions();
            configuration.GetSection(MailOptions.SectionKey).Bind(mailOptions);
            return mailOptions;
        }
    }
}
