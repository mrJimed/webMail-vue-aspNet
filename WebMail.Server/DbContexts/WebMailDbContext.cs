using Microsoft.EntityFrameworkCore;
using WebMail.Server.Models;

namespace WebMail.Server.DbContexts
{
    public class WebMailDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; } = null!;
    }
}
