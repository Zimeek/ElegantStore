using ElegantStore.Api.DTOs;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;
using Mapster;

namespace ElegantStore.Api.MappingRegisters;

public class ProductColorRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProductColor, ProductColorDTO>()
            .Map(dest => dest.Name, src => src.Color.Name);
    }
}