using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support2.Areas.Identity.Data;

namespace Support2.Data;

public class Support2Context : IdentityDbContext<Support2User>
{
    public Support2Context(DbContextOptions<Support2Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    private class ApplicationUserEntityConfiguration :
IEntityTypeConfiguration<Support2User>
    {
        public void Configure(EntityTypeBuilder<Support2User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(255);
            builder.Property(x => x.LastName).HasMaxLength(255);
        }
    }
    public class Support2ContextFactory : IDesignTimeDbContextFactory<Support2Context>
    {
        public Support2Context CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<Support2Context>();
            var connectionString = configuration.GetConnectionString("Support2ContextConnection");

            builder.UseSqlServer(connectionString);

            return new Support2Context(builder.Options);
        }
    }

}
