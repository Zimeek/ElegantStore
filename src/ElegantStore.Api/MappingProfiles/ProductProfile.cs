using AutoMapper;
using ElegantStore.Api.DTOs;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;

namespace ElegantStore.Api.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDTO>();
    }   
}