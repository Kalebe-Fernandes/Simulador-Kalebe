using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Infraestrututra.Context;
using SimuladorCredito.Infraestrututra.Repositories.Interfaces;

namespace SimuladorCredito.Infraestrututra.Repositories
{
    public class ProductRepository(ApplicationDbContext context) : Repository<Product>(context), IProductRepository
    {
        public async Task<IEnumerable<Product>> GetProductByPersonTypeAsync(int personTypeId)
        {
            return await _context.Products
                .Where(p => p.PersonTypeId == personTypeId)
                .ToListAsync();
        }
    }
}
