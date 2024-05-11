using ToDoList.Domain.Classes;

namespace ToDoList.Domain.DomainErrors
{
    public static class DomainErrors
    {
        public static class Application
        {
            public static Error InternalError => new(
                "Application.InternalError",
                "An unidentified error has occurred"
                );
        }
        public static class Tasks
        {
            public static Error InvalidDueDate => new(
                "Tasks.InvalidDueDate",
                $"The only way to create the task with the informed due date it`s with a time machine");
            public static Error NotFound(Guid id) => new(
                "Tasks.NotFound",
                $"The task with id {id} was not found");
        }
    }

}
