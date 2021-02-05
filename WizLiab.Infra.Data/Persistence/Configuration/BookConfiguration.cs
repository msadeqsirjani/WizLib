using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib.Domain.Entities;
using WizLib.Infra.Data.Persistence.Configuration.Common;

namespace WizLib.Infra.Data.Persistence.Configuration
{
    public class BookConfiguration : BaseEntityConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Isbn)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnName("ISBN")
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasMaxLength(3000000);
            builder.Property(x => x.CategoryId)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.BookDetail)
                .WithOne(x => x.Book)
                .HasForeignKey<Book>(x => x.BookDetailId);

            builder.HasOne(x => x.Publisher)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.PublisherId);


            base.Configure(builder);
        }
    }
}
