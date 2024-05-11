﻿namespace ToDoList.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;

        public ICollection<ToDoTask> Tasks { get; private set; }
    }
}
