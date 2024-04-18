using Portfolio.Domain.Features.Products.Dtos.Products;
using Portfolio.Domain.Features.Products.Models;
using Mapster;

namespace Portfolio.Application.Features.Products.Mapping
{
    internal class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Product, ProductDto>()
                 .Map(dest => dest.Name,
                    src => src.Name.GetCulturedValue())
                 .Map(dest => dest.Images,
                    src => src.Images.Select(x => x.MappFile(FileHelper.Home)).ToList());

            config.NewConfig<CreateProductDto, Product>()
                 .Map(dest => dest.Images,
                    src => src.Images.Select(x => FileHelper.Upload(x, FileHelper.Product)));
        }
    }
}
