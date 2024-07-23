using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webMail.Server.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; private set; } = Guid.NewGuid();

        [Column("username", TypeName = "varchar")]
        public required string Username { get; set; }

        [Column("email", TypeName = "varchar")]
        public required string Email { get; set; }

        [Column("password", TypeName = "varchar")]
        public required string Password { get; set; }

        [Column("salt", TypeName = "varchar")]
        public required string Salt { get; set; }

        public virtual List<MailHistory> MailHistories { get; set; } = [];
    }
}
