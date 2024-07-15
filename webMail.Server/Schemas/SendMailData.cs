using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webMail.Server.Schemas
{
    public class SendMessageData
    {
        [Required(ErrorMessage = "Отсутствует тема письма.")]
        [JsonPropertyName("subject")]
        public required string Subject { get; init; }

        [Required(ErrorMessage = "Отсутствует текст письма.")]
        [JsonPropertyName("text")]
        public required string Text { get; init; }

        [Required(ErrorMessage = "Отсутствует email адресата.")]
        [JsonPropertyName("toEmail")]
        public required string ToEmail { get; init; }
    }
}
