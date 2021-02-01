using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib.Domain.Entities;
using WizLib.Infra.Data.Persistence.Configuration.Common;

namespace WizLib.Infra.Data.Persistence.Configuration
{
    public class AuthorBookConfiguration : BaseEntityConfiguration<AuthorBook>
    {
        public override void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.ToTable("AuthorBook");

            builder.HasKey(x => new { x.AuthorId, x.BookId });

            builder.Property(x => x.AuthorId)
                .IsRequired();

            builder.Property(x => x.BookId)
                .IsRequired();

            builder.HasOne(x => x.Author)
                .WithMany(x => x.AuthorBooks)
                .HasForeignKey(x => x.AuthorId);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.AuthorBooks)
                .HasForeignKey(x => x.BookId);

            builder.Ignore(x => x.Id);
        }
    }
}
