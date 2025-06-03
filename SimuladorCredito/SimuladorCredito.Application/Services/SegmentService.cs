using AutoMapper;
using SimuladorCredito.Application.DTOs;
using SimuladorCredito.Application.Services.Interfaces;
using SimuladorCredito.Infraestrututra.Repositories.UnitOfWork;

namespace SimuladorCredito.Application.Services
{
    public class SegmentService(IUnitOfWork unitOfWork, IMapper mapper) : ISegmentService
    {
        protected readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        protected readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<IEnumerable<SegmentDTO>> GetAllAsync()
        {
            var segments = await _unitOfWork.SegmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SegmentDTO>>(segments);
        }

        public async Task<SegmentDTO> GetSegmentByPersonTypeAsync(string personTypeId, decimal minimumIncome)
        {
            var productService = new ProductService(_unitOfWork, _mapper);

            PersonTypeDTO personType;
            try
            {
                personType = await productService.GetPersonTypeForProduct(personTypeId);
            }
            catch (KeyNotFoundException)
            {
                return null;
            }

            var segments = await _unitOfWork.SegmentRepository.GetSegmentByPersonTypeAsync(personType.Id);
            var segment = segments.Where(s => s.MinimumIncome <= minimumIncome).LastOrDefault();
            return _mapper.Map<SegmentDTO>(segment);
        }

        public string Ping()
        {
            return _unitOfWork.Ping();
        }
    }
}
