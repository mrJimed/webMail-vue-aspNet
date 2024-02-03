using Microsoft.EntityFrameworkCore;
using WebMail.Server.Models;

namespace WebMail.Server.DbContexts
{
    public class WebMailDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public WebMailDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
