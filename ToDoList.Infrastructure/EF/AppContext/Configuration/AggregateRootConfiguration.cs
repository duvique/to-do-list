using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.EF.AppContext.Configuration
{
    public class AggregateRootConfiguration<TAggregateRoot> : EntityConfiguration<TAggregateRoot>
        where TAggregateRoot : AggregateRoot, IAggregateRoot
    {
        public override void Configure(EntityTypeBuilder<TAggregateRoot> builder)
        {
            base.Configure(builder);

        }
    }
}
