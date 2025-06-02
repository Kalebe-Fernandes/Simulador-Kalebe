namespace SimuladorCredito.Application.DTOs
{
    public class RateDTO : EntityDTO
    {
        public float Value { get; set; }
        public int PersonTypeId { get; set; }
        public int ProductId { get; set; }
        public int SegmentId { get; set; }
        public int ModalityId { get; set; }
    }
}
