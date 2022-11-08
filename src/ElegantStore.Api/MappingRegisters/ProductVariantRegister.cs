using ElegantStore.Api.DTOs;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;
using Mapster;

namespace ElegantStore.Api.MappingRegisters;

public class ProductVariantRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProductVariant, ProductVariantDTO>()
            .Map(dest => dest.Name, src => src.Color.Name);
    }
}