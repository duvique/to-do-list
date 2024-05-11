using ToDoList.Application.Contracts;
using ToDoList.Domain.Enumerators;

namespace ToDoList.Application.Tasks.Commands.CreateTask
{
    public sealed record CreateTaskCommand(string Name, string Description, DateTime? DueDate, EVisibilityType Visibility) : ICommand<Guid>
    {
    }
}
