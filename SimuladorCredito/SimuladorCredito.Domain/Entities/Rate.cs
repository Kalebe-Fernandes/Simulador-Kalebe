using System.Text.Json.Serialization;

namespace SimuladorCredito.Domain.Entities
{
    public class Rate : Entity
    {
        public float Value { get; set; }

        public int PersonTypeId { get; set; }
        [JsonIgnore]
        public PersonType PersonType { get; set; } = null!;

        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; } = null!;

        public int SegmentId { get; set; }
        [JsonIgnore]
        public Segment Segment { get; set; } = null!;

        public int ModalityId { get; set; }
        [JsonIgnore]
        public Modality Modality { get; set; } = null!;

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Value)}: {Value}%";
        }
    }
}
