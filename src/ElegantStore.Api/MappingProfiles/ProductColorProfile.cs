using AutoMapper;
using ElegantStore.Api.DTOs;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;

namespace ElegantStore.Api.MappingProfiles;

public class ProductColorProfile : Profile
{
    public ProductColorProfile()
    {
        CreateMap<ProductColor, ProductColorDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Color.Name));
    }
}