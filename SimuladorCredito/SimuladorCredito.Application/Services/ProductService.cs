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

        public async Task<PersonTypeDTO> GetPersonTypeForProduct(string personTypeName)
        {
            if (string.IsNullOrWhiteSpace(personTypeName))
            {
                throw new ArgumentException("Person type name cannot be null or empty.", nameof(personTypeName));
            }

            var personTypes = await _unitOfWork.PersonTypeRepository.GetAllAsync();
            var personType = personTypes.FirstOrDefault(pt => pt.Name.Equals(personTypeName, StringComparison.OrdinalIgnoreCase));
            if (personType == null)
            {
                throw new KeyNotFoundException($"Person type '{personTypeName}' not found.");
            }

            return _mapper.Map<PersonTypeDTO>(personType);
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
