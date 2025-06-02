using AutoMapper;
using SimuladorCredito.Application.DTOs;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Application.Mappers
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<PersonType, PersonTypeDTO>();
            CreateMap<Modality, ModalityDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Segment, SegmentDTO>();
            CreateMap<Rate, RateDTO>();
        }
    }
}
