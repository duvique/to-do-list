using ToDoList.Domain.Entities;
using ToDoList.Domain.Enumerators;

namespace ToDoList.Application.Tasks.Queries
{
    public sealed record TaskResponse(
          Guid Id,
          string Name,
          string Description,
          EVisibilityType Visibility,
          DateTime? DueDate,
          bool IsFinished,
          DateTime? FinishedDate)
    {
        public static TaskResponse Map(ToDoTask task) => new(
                    task.Id,
                    task.Name,
                    task.Description,
                    task.Visibility,
                    task.DueDate,
                    task.IsFinished,
                    task.FinishedDate);
    }
}
