using Portfolio.Domain.Features.Categories.Dtos;
using Portfolio.Domain.Features.Categories.Models;
using Mapster;

namespace Portfolio.Application.Features.Categories.Mapping
{
    internal class CategoryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Category, CategoryDto>()
                 .Map(dest => dest.Name,
                    src => src.Name.GetCulturedValue())
                 .Map(dest => dest.Description,
                    src => src.Description.GetCulturedValue())
                 .Map(dest => dest.Image,
                    src => src.Image.MappFile(FileHelper.Category));

            config.NewConfig<Category, CategoryLookUpDto>()
                 .Map(dest => dest.Name,
                    src => src.Name.GetCulturedValue());

            config.NewConfig<CreateCategoryDto, Category>()
                 .Map(dest => dest.Image,
                    src => FileHelper.Upload(src.Image, FileHelper.Category));
        }
    }
}
