using AutoMapper;
using SimuladorCredito.Application.DTOs;
using SimuladorCredito.Application.Services.Interfaces;
using SimuladorCredito.Infraestrututra.Repositories.UnitOfWork;

namespace SimuladorCredito.Application.Services
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        protected readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        protected readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductByPersonTypeAsync(int personTypeId)
        {
            if (personTypeId <= 0)
            {
                throw new ArgumentException("Person type ID must be greater than zero.", nameof(personTypeId));
            }

            var products = await _unitOfWork.ProductRepository.GetProductByPersonTypeAsync(personTypeId);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public string Ping()
        {
            return _unitOfWork.Ping();
        }
    }
}
