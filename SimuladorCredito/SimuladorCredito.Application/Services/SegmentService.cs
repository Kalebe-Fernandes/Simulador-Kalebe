using AutoMapper;
using SimuladorCredito.Application.DTOs;
using SimuladorCredito.Application.Services.Interfaces;
using SimuladorCredito.Infraestrututra.Repositories.UnitOfWork;

namespace SimuladorCredito.Application.Services
{
    public class SegmentService(IUnitOfWork unitOfWork, IMapper mapper) : Service<SegmentDTO>(unitOfWork, mapper), ISegmentService
    {
        public async Task<SegmentDTO> GetSegmentByPersonTypeAsync(int personTypeId, decimal minimumIncome)
        {
            if (personTypeId <= 0)
            {
                throw new ArgumentException("Person type ID must be greater than zero.", nameof(personTypeId));
            }

            var segments = await _unitOfWork.SegmentRepository.GetSegmentByPersonTypeAsync(personTypeId);
            var segment = segments.LastOrDefault(s => s.MinimumIncome >= minimumIncome);
            return _mapper.Map<SegmentDTO>(segment);
        }
    }
}
