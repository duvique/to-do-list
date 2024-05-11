using ToDoList.Application.Contracts;

namespace ToDoList.Application.Tasks.Commands.FinishTask
{
    public sealed record FinishTaskCommand(Guid TaskId) : ICommand<bool>
    {
    }
}
