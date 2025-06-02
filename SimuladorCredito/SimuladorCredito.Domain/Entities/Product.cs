namespace SimuladorCredito.Domain.Entities
{
    public class Product : Entity
    {
        public required string Name { get; set; }

        public int PersonTypeId { get; set; }
        public PersonType PersonType { get; set; } = null!;

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }
}
