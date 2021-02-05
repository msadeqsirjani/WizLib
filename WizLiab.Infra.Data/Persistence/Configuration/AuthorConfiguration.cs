using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib.Domain.Entities;
using WizLib.Infra.Data.Persistence.Configuration.Common;

namespace WizLib.Infra.Data.Persistence.Configuration
{
    public class AuthorConfiguration : BaseEntityConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(x => x.Forename)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Birthdate)
                .IsRequired();

            builder.Property(x => x.Location)
                .IsRequired()
                .HasMaxLength(64);

            builder.Ignore(x => x.Fullname);

            base.Configure(builder);
        }
    }
}
