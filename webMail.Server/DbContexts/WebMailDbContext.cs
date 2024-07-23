using Microsoft.EntityFrameworkCore;
using webMail.Server.Models;

namespace webMail.Server.DbContexts
{
    public class WebMailDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<MailHistory> MailHistories { get; set; } = null!;
    }
}
