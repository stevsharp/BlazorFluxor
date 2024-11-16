
namespace Domain.Common
{
    public abstract class Entity<T>
    {
        public T Id { get; init; }

        protected readonly List<IDomainEvent> _domainEvents = [];

        protected Entity(T id) => Id = id;

        public List<IDomainEvent> PopDomainEvents()
        {
            var copy = _domainEvents.ToList();

            _domainEvents.Clear();

            return copy;
        }

        protected Entity()
        {
        }
    }
}
