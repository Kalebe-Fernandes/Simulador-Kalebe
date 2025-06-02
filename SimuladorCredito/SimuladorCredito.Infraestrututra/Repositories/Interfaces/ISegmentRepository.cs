using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Infraestrututra.Repositories.Interfaces
{
    public interface ISegmentRepository : IRepository<Segment>
    {
        Task<IEnumerable<Segment>> GetSegmentByPersonTypeAsync(int personTypeId);
    }
}
