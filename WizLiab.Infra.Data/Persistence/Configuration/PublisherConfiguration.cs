using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib.Domain.Entities;
using WizLib.Infra.Data.Persistence.Configuration.Common;

namespace WizLib.Infra.Data.Persistence.Configuration
{
    public class PublisherConfiguration : BaseEntityConfiguration<Publisher>
    {
        public override void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Location)
                .IsRequired()
                .HasMaxLength(64);

            base.Configure(builder);
        }
    }
}