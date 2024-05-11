namespace ToDoList.Domain.Entities
{
    public class Entity<TIdentifier>
        where TIdentifier :
            IEquatable<TIdentifier>, IComparable<TIdentifier>, new()
    {
        public virtual TIdentifier Id { get; private set; }
        public virtual DateTime CreatedAt { get; protected set; } = DateTime.Now;
        public virtual DateTime UpdatedAt { get; protected set; } = DateTime.Now;
        protected Entity(TIdentifier id)
        {
            Id = EqualityComparer<TIdentifier>.Default.Equals(id, default)
                ? new TIdentifier()
                : id;
        }

        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
