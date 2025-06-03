using SimuladorCredito.Application.DTOs;

namespace SimuladorCredito.Application.Services.Interfaces
{
    public interface IProductService : IService<ProductDTO>
    {
        Task<PersonTypeDTO> GetPersonTypeForProduct(string personTypeName);
        Task<IEnumerable<ProductDTO>> GetProductByPersonTypeAsync(int personTypeId);
    }
}
