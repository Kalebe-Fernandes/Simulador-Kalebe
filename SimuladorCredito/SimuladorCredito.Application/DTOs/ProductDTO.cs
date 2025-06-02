namespace SimuladorCredito.Application.DTOs
{
    public class ProductDTO : EntityDTO
    {
        public required string Name { get; set; }
        public int PersonTypeId { get; set; }
    }
}
