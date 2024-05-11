using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Enumerators;

namespace ToDoList.Infrastructure.EF.AppContext.Configuration
{
    internal class TaskConfiguration : AggregateRootConfiguration<ToDoTask>
    {
        public override void Configure(EntityTypeBuilder<ToDoTask> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Visibility)
                .HasConversion(
                    v => v.ToString(),
                    v => (EVisibilityType)Enum.Parse(typeof(EVisibilityType), v));
        }
    }
}
