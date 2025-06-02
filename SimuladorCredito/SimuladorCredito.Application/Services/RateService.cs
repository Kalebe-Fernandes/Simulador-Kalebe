using AutoMapper;
using SimuladorCredito.Application.DTOs;
using SimuladorCredito.Application.Services.Interfaces;
using SimuladorCredito.Infraestrututra.Repositories.UnitOfWork;

namespace SimuladorCredito.Application.Services
{
    public class RateService(IUnitOfWork unitOfWork, IMapper mapper) : IRateService
    {
        protected readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        protected readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<IEnumerable<RateDTO>> GetAllAsync()
        {
            return await _unitOfWork.RateRepository.GetAllAsync().ContinueWith(task => _mapper.Map<IEnumerable<RateDTO>>(task.Result));
        }

        public async Task<RateDTO> GetRateByAsync(int personTypeId, int modalityId, int productId, int segmentId)
        {
            if (personTypeId <= 0)
            {
                throw new ArgumentException("Person type ID must be greater than zero.", nameof(personTypeId));
            }
            if (modalityId <= 0)
            {
                throw new ArgumentException("Modality ID must be greater than zero.", nameof(modalityId));
            }
            if (productId <= 0)
            {
                throw new ArgumentException("Product ID must be greater than zero.", nameof(productId));
            }
            if (segmentId <= 0)
            {
                throw new ArgumentException("Segment ID must be greater than zero.", nameof(segmentId));
            }

            var rate = await _unitOfWork.RateRepository.GetRateByAsync(personTypeId, modalityId, productId, segmentId);
            return _mapper.Map<RateDTO>(rate);
        }

        public string Ping()
        {
            return _unitOfWork.Ping();
        }
    }
}
