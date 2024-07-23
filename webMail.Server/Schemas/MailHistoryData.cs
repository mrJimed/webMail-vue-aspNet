using System.Text.Json.Serialization;

namespace webMail.Server.Schemas
{
    public class MailHistoryData : SendMessageData
    {
        [JsonPropertyName("createDt")]
        public required DateTime CreateDt { get; set; }
    }
}
