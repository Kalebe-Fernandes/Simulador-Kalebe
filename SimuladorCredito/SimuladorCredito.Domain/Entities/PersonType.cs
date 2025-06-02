using System.Text.Json.Serialization;

namespace SimuladorCredito.Domain.Entities
{
    public class PersonType : Entity
    {
        public required string Name { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = [];
        [JsonIgnore]
        public ICollection<Segment> Segments { get; set; } = [];
        [JsonIgnore]
        public ICollection<Rate> Rates { get; set; } = [];

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }
}
