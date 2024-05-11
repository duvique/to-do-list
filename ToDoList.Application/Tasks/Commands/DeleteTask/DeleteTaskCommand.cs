using ToDoList.Application.Contracts;

namespace ToDoList.Application.Tasks.Commands.DeleteTask
{
    public sealed record DeleteTaskCommand(Guid TaskId) : ICommand<bool>
    {

    }
}
