using AutoMapper;
using SimuladorCredito.Application.DTOs;
using SimuladorCredito.Application.Services.Interfaces;
using SimuladorCredito.Infraestrututra.Repositories.UnitOfWork;

namespace SimuladorCredito.Application.Services
{
    public class PersonTypeService(IUnitOfWork unitOfWork, IMapper mapper) : IPersonTypeService
    {
        protected readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        protected readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<IEnumerable<PersonTypeDTO>> GetAllAsync()
        {
            var personTypes = await _unitOfWork.PersonTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonTypeDTO>>(personTypes);
        }

        public string Ping()
        {
            return _unitOfWork.Ping();
        }
    }
}
