using Portfolio.Domain.Features.Products.Dtos.ExtraDetails;
using Portfolio.Domain.Features.Products.Models;
using Mapster;

namespace Portfolio.Application.Features.Products.Mapping
{
    internal class ProductExtraDetailsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductExtraDetails, ProductExtraDetailsDto>()
                 .Map(dest => dest.Title,
                    src => src.Title.GetCulturedValue())
                 .Map(dest => dest.Description,
                    src => src.Description.GetCulturedValue());
        }
    }
}
