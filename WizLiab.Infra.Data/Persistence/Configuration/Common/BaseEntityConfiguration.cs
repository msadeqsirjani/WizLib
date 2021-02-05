using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib.Domain.Common;

namespace WizLib.Infra.Data.Persistence.Configuration.Common
{
    public class BaseEntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity> where TKey : struct where TEntity : BaseEntity<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasKey(b => b.Id);
        }
    }

    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasKey(b => b.Id);
        }
    }
}
