using SimuladorCredito.Infraestrututra.Repositories.Interfaces;

namespace SimuladorCredito.Infraestrututra.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;
        IPersonTypeRepository PersonTypeRepository { get; }
        IProductRepository ProductRepository { get; }
        IRateRepository RateRepository { get; }
        IModalityRepository ModalityRepository { get; }
        ISegmentRepository SegmentRepository { get; }

        string Ping();
        Task<int> Commit();
        void Dispose();
    }
}
