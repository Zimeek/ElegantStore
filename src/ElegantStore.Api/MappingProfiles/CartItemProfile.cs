using AutoMapper;
using ElegantStore.Api.DTOs;
using ElegantStore.Domain.Entities.Aggregates.CartAggregate;

namespace ElegantStore.Api.MappingProfiles;

public class CartItemProfile : Profile
{
    public CartItemProfile()
    {
        CreateMap<CartItem, CartItemDTO>();
    }
}