using AutoMapper;
using SimuladorCredito.Application.DTOs;
using SimuladorCredito.Application.Services.Interfaces;
using SimuladorCredito.Infraestrututra.Repositories.UnitOfWork;

namespace SimuladorCredito.Application.Services
{
    public class ModalityService(IUnitOfWork unitOfWork, IMapper mapper) : IModalityService
    {
        protected readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        protected readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<IEnumerable<ModalityDTO>> GetAllAsync()
        {
            var modalities = await _unitOfWork.ModalityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ModalityDTO>>(modalities);
        }

        public string Ping()
        {
            return _unitOfWork.Ping();
        }
    }
}
