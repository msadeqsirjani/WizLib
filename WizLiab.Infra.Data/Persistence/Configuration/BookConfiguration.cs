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

            base.Configure(builder);
        }
    }
}
