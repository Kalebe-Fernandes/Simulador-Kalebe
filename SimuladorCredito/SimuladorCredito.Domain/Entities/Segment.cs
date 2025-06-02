using System.Text.Json.Serialization;

namespace SimuladorCredito.Domain.Entities
{
    public class Segment : Entity
    {
        public required string Name { get; set; }
        public required decimal MinimumIncome { get; set; }

        public int PersonTypeId { get; set; }

        [JsonIgnore]
        public PersonType PersonType { get; set; } = null!;
        [JsonIgnore]
        public ICollection<Rate> Rates { get; set; } = [];

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }
}
