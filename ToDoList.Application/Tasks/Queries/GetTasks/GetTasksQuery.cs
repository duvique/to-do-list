using ToDoList.Application.Contracts;

namespace ToDoList.Application.Tasks.Queries.GetTasks
{
    public class GetTasksQuery : IQuery<IEnumerable<TaskResponse>>;
}
