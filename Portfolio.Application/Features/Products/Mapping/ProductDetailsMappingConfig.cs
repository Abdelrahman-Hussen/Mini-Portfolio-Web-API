using Portfolio.Domain.Features.Products.Dtos.Details;
using Portfolio.Domain.Features.Products.Models;
using Mapster;

namespace Portfolio.Application.Features.Products.Mapping
{
    internal class ProductDetailsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductDetails, ProductDetailsDto>()
                 .Map(dest => dest.Content,
                    src => src.Content.GetCulturedValue());
        }
    }
}
