using AutoMapper;
using SimuladorCredito.Application.DTOs;
using SimuladorCredito.Application.Services.Interfaces;
using SimuladorCredito.Infraestrututra.Repositories.UnitOfWork;

namespace SimuladorCredito.Application.Services
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : Service<ProductDTO>(unitOfWork, mapper), IProductService
    {
        public async Task<IEnumerable<ProductDTO>> GetProductByPersonTypeAsync(int personTypeId)
        {
            if (personTypeId <= 0)
            {
                throw new ArgumentException("Person type ID must be greater than zero.", nameof(personTypeId));
            }

            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}
