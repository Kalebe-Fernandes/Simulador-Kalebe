namespace SimuladorCredito.Application.DTOs
{
    public class SegmentDTO : EntityDTO
    {
        public required string Name { get; set; }
        public required decimal MinimumIncome { get; set; }
        public int PersonTypeId { get; set; }
    }
}
