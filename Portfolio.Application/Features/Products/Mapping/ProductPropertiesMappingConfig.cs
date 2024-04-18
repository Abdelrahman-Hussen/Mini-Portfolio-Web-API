using Portfolio.Domain.Features.Products.Dtos.Properties;
using Portfolio.Domain.Features.Products.Models;
using Mapster;

namespace Portfolio.Application.Features.Products.Mapping
{
    internal class ProductPropertiesMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductProperties, ProductPropertiesDto>()
                 .Map(dest => dest.Name,
                    src => src.Name.GetCulturedValue());
        }
    }
}
