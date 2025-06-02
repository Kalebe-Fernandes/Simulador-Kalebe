namespace SimuladorCredito.Domain.Entities
{
    public class Modality : Entity
    {
        public required string Name { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }
}
