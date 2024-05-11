using ToDoList.Application.Contracts;

namespace ToDoList.Application.Tasks.Queries.GetTaskById
{
    public sealed record GetTaskByIdQuery(Guid TaskId) : IQuery<TaskResponse>;
}
