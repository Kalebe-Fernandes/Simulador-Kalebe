using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Infraestrututra.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductByPersonTypeAsync(int personTypeId);
    }
}
