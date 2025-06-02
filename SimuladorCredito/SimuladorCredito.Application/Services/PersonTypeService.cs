using AutoMapper;
using SimuladorCredito.Application.DTOs;
using SimuladorCredito.Application.Services.Interfaces;
using SimuladorCredito.Infraestrututra.Repositories.UnitOfWork;

namespace SimuladorCredito.Application.Services
{
    public class PersonTypeService(IUnitOfWork unitOfWork, IMapper mapper) : Service<PersonTypeDTO>(unitOfWork, mapper), IPersonTypeService
    {
    }
}
