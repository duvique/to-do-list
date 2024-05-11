using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.EF.AppContext.Configuration
{
    public class AggregateRootConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : Entity<Guid>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

        }
    }

    public class AggregateRootConfiguration<TEntity, TIdentifier> : EntityConfiguration<TEntity, TIdentifier>
        where TIdentifier
            : IComparable<TIdentifier>, IEquatable<TIdentifier>, new()
        where TEntity : Entity<TIdentifier>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
