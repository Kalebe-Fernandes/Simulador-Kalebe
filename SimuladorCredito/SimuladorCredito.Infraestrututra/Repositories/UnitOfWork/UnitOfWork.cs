﻿using SimuladorCredito.Infraestrututra.Context;
using SimuladorCredito.Infraestrututra.Repositories.Interfaces;

namespace SimuladorCredito.Infraestrututra.Repositories.UnitOfWork
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;

        private IPersonTypeRepository _personRepository;
        public IPersonTypeRepository PersonTypeRepository => _personRepository ?? new PersonTypeRepository(_context);

        private IProductRepository _productRepository;
        public IProductRepository ProductRepository => _productRepository ?? new ProductRepository(_context);

        private IRateRepository _rateRepository;
        public IRateRepository RateRepository => _rateRepository ?? new RateRepository(_context);

        private IModalityRepository _modalityRepository;
        public IModalityRepository ModalityRepository => _modalityRepository ?? new ModalityRepository(_context);

        private ISegmentRepository _segmentRepository;
        public ISegmentRepository SegmentRepository => _segmentRepository ?? new SegmentRepository(_context);

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public string Ping()
        {
            return "Pong!";
        }
    }
}
