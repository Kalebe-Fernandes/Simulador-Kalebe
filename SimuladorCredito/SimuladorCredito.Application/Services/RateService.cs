using AutoMapper;
using SimuladorCredito.Application.DTOs;
using SimuladorCredito.Application.Services.Interfaces;
using SimuladorCredito.Infraestrututra.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorCredito.Application.Services
{
    public class RateService(IUnitOfWork unitOfWork, IMapper mapper) : Service<RateDTO>(unitOfWork, mapper), IRateService
    {
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
    }
}
