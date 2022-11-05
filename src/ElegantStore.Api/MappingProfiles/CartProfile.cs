using AutoMapper;
using ElegantStore.Api.DTOs;
using ElegantStore.Domain.Entities.Aggregates.CartAggregate;

namespace ElegantStore.Api.MappingProfiles;

public class CartProfile : Profile
{
    public CartProfile()
    {
        CreateMap<Cart, CartDTO>();
    }
}