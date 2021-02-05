using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib.Domain.Entities;
using WizLib.Infra.Data.Persistence.Configuration.Common;

namespace WizLib.Infra.Data.Persistence.Configuration
{
    public class GenreConfiguration : BaseEntityConfiguration<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.DisplayOrder)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
