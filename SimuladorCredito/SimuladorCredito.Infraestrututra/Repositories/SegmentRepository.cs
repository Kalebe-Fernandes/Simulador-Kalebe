using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Infraestrututra.Context;
using SimuladorCredito.Infraestrututra.Repositories.Interfaces;

namespace SimuladorCredito.Infraestrututra.Repositories
{
    public class SegmentRepository(ApplicationDbContext context) : Repository<Segment>(context), ISegmentRepository
    {
        public async Task<IEnumerable<Segment>> GetSegmentByPersonTypeAsync(int personTypeId)
        {
            return await _context.Segments
                .Where(s => s.PersonTypeId == personTypeId)
                .ToListAsync();
        }
    }
}
