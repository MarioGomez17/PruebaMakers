namespace PruebaTecnica.Domain.Models
{
    public abstract class Entity
    {
        protected Entity(Guid Id)
        {
            this.Id = Id;
        }
        public Guid Id { get; init; }

    }
}
