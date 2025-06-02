using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Infraestrututra.Context;
using SimuladorCredito.Infraestrututra.Repositories.Interfaces;

namespace SimuladorCredito.Infraestrututra.Repositories
{
    public class PersonTypeRepository(ApplicationDbContext context) : Repository<PersonType>(context), IPersonTypeRepository
    {
    }
}
