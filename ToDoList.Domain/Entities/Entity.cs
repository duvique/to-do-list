namespace ToDoList.Domain.Entities
{
    public class Entity : Entity<Guid>
    {
        protected Entity() : base(default) { }
        protected Entity(Guid id) : base(id)
        {
        }
    }
}
