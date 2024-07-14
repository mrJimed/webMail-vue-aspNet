namespace webMail.Server.Options
{
    public class MailOptions
    {
        public const string SectionKey = "Mail";

        public string Host { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
