using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webMail.Server.Models
{
    [Table("mail_history")]
    public class MailHistory
    {
        [Key]
        [Column("id")]
        public Guid Id { get; private set; } = Guid.NewGuid();

        [Column("create_dt")]
        public DateTime CreateDt { get; private set; } = DateTime.UtcNow;

        [Column("subject", TypeName = "varchar")]
        public required string Subject { get; set; }

        [Column("text", TypeName = "text")]
        public required string Text { get; set; }

        [Column("to_email", TypeName = "varchar")]
        public required string ToEmail { get; set; }

        [ForeignKey("sender")]
        public virtual required User Sender { get; set; } 
    }
}
