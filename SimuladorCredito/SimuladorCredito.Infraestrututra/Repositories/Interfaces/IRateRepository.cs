using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Infraestrututra.Repositories.Interfaces
{
    public interface IRateRepository : IRepository<Rate>
    {
        Task<Rate> GetRateByAsync(int personTypeId, int modalityId, int productId, int segmentId);
    }
}
