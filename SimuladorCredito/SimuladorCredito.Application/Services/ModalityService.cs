using AutoMapper;
using SimuladorCredito.Application.DTOs;
using SimuladorCredito.Application.Services.Interfaces;
using SimuladorCredito.Infraestrututra.Repositories.UnitOfWork;

namespace SimuladorCredito.Application.Services
{
    public class ModalityService(IUnitOfWork unitOfWork, IMapper mapper) : Service<ModalityDTO>(unitOfWork, mapper), IModalityService
    {
    }
}
