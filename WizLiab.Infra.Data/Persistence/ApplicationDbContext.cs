using Microsoft.EntityFrameworkCore;
using WizLib.Domain.Entities;
using WizLib.Infra.Data.Persistence.Configuration;

namespace WizLib.Infra.Data.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
