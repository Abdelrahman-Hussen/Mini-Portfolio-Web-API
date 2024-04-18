namespace Portfolio.Domain.Primitives
{
    public class EntityWithId : Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
