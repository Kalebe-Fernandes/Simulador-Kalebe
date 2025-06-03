using AutoMapper;
using SimuladorCredito.Application.DTOs;
using SimuladorCredito.Application.Services.Interfaces;
using SimuladorCredito.Infraestrututra.Repositories.UnitOfWork;

namespace SimuladorCredito.Application.Services
{
    public class RateService(IUnitOfWork unitOfWork, IMapper mapper) : IRateService
    {
        protected readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        protected readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<IEnumerable<RateDTO>> GetAllAsync()
        {
            return await _unitOfWork.RateRepository.GetAllAsync().ContinueWith(task => _mapper.Map<IEnumerable<RateDTO>>(task.Result));
        }

        public async Task<RateDTO> GetRateByAsync(string personTypeName, string modalityName, string productName, string segmentName)
        {
            if (string.IsNullOrWhiteSpace(personTypeName) || string.IsNullOrWhiteSpace(modalityName) ||
                string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(segmentName))
            {
                throw new ArgumentException("All parameters must be provided and cannot be null or empty.");
            }

            var productService = new ProductService(_unitOfWork, _mapper);
            var personType = await productService.GetPersonTypeForProduct(personTypeName);
            var modality = await GetModalityForRate(modalityName);
            var product = await GetProductForRate(productName);
            var segment = await GetSegmentForRate(segmentName);

            var rate = await _unitOfWork.RateRepository.GetRateByAsync(personType.Id, modality, product, segment);
            return _mapper.Map<RateDTO>(rate);
        }

        private async Task<int> GetModalityForRate(string modalityName)
        {
            var modalities = await _unitOfWork.ModalityRepository.GetAllAsync();
            var modality = modalities.FirstOrDefault(m => m.Name.Equals(modalityName, StringComparison.OrdinalIgnoreCase));
            if (modality == null)
            {
                throw new ArgumentException($"Modality '{modalityName}' not found.");
            }

            return modality.Id;
        }

        private async Task<int> GetSegmentForRate(string segmentName)
        {
            var segments = await _unitOfWork.SegmentRepository.GetAllAsync();
            var segment = segments.FirstOrDefault(m => m.Name.Equals(segmentName, StringComparison.OrdinalIgnoreCase));
            if (segment == null)
            {
                throw new ArgumentException($"Modality '{segmentName}' not found.");
            }

            return segment.Id;
        }

        private async Task<int> GetProductForRate(string productName)
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            var product = products.FirstOrDefault(m => m.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                throw new ArgumentException($"Modality '{productName}' not found.");
            }

            return product.Id;
        }

        public string Ping()
        {
            return _unitOfWork.Ping();
        }
    }
}
