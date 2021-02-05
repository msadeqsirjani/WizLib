using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib.Domain.Entities;
using WizLib.Infra.Data.Persistence.Configuration.Common;

namespace WizLib.Infra.Data.Persistence.Configuration
{
    public class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);

            base.Configure(builder);
        }
    }
}
