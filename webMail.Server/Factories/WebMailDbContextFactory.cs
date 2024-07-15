using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using webMail.Server.DbContexts;

namespace webMail.Server.Factories
{
    public class WebMailDbContextFactory : IDesignTimeDbContextFactory<WebMailDbContext>
    {
        public WebMailDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebMailDbContext>();

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new WebMailDbContext(optionsBuilder.Options);
        }
    }
}
