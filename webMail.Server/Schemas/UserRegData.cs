using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webMail.Server.Schemas
{
    public class UserRegData : UserLoginData
    {
        [Required(ErrorMessage = "Отсутствует имя пользователя.")]
        [JsonPropertyName("username")]
        public required string Username { get; set; }
    }
}
