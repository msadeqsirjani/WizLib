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
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new PublisherConfiguration())

            base.OnModelCreating(builder);

            try
            {
                Database.Migrate();
            }
            catch
            {
                //ignore
            }
        }
    }
}
