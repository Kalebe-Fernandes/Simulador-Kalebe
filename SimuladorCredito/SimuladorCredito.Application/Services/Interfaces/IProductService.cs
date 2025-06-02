using SimuladorCredito.Application.DTOs;

namespace SimuladorCredito.Application.Services.Interfaces
{
    public interface IProductService : IService<ProductDTO>
    {
        Task<IEnumerable<ProductDTO>> GetProductByPersonTypeAsync(int personTypeId);
    }
}
