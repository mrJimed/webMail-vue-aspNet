using System.Text.Json.Serialization;

namespace webMail.Server.Schemas
{
    public class SendMessageData
    {
        [JsonPropertyName("subject")]
        public string Subject { get; init; }

        [JsonPropertyName("text")]
        public string Text { get; init; }

        [JsonPropertyName("toEmail")]
        public string ToEmail { get; init; }
    }
}
