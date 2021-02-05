using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib.Domain.Entities;
using WizLib.Infra.Data.Persistence.Configuration.Common;

namespace WizLib.Infra.Data.Persistence.Configuration
{
    public class BookDetailConfiguration : BaseEntityConfiguration<BookDetail>
    {
        public override void Configure(EntityTypeBuilder<BookDetail> builder)
        {
            builder.Property(x => x.NumberOfChapters)
                .IsRequired();

            builder.Property(x => x.NumberOfPages)
                .IsRequired();

            builder.Property(x => x.Weight);

            base.Configure(builder);
        }
    }
}
