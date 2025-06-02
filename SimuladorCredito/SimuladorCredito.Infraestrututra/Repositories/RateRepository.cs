using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Infraestrututra.Context;
using SimuladorCredito.Infraestrututra.Repositories.Interfaces;

namespace SimuladorCredito.Infraestrututra.Repositories
{
    public class RateRepository(ApplicationDbContext context) : Repository<Rate>(context), IRateRepository
    {
        public async Task<Rate> GetRateByAsync(int personTypeId, int modalityId, int productId, int segmentId)
        {
            return await _context.Rates
                .FirstAsync(r => r.PersonTypeId == personTypeId &&
                            r.ModalityId == modalityId &&
                            r.ProductId == productId &&
                            r.SegmentId == segmentId);
        }
    }
}
