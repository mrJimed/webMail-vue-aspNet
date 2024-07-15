using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webMail.Server.Schemas
{
    public class UserLoginData
    {
        [Required(ErrorMessage = "Отсутствует email.")]
        [JsonPropertyName("email")]
        public required string Email { get; set; }

        [MinLength(4, ErrorMessage = "Минимальная длина пароля должна быть 4 символа.")]
        [MaxLength(16, ErrorMessage = "Пароль не должен превышать 16 символов.")]
        [JsonPropertyName("password")]
        public required string Password { get; set; }
    }
}
