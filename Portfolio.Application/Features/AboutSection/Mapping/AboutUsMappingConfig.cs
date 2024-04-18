using Portfolio.Domain.Features.AboutSection.Dtos.About;
using Portfolio.Domain.Features.AboutSection.Models;
using Mapster;

namespace Portfolio.Application.Features.AboutSection.Mapping
{
    internal class AboutUsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AboutUs, AboutUsDto>()
                 .Map(dest => dest.Header,
                    src => src.Header.GetCulturedValue())
                 .Map(dest => dest.Description,
                    src => src.Description.GetCulturedValue())
                 .Map(dest => dest.Image,
                    src => src.Image.MappFile(FileHelper.AboutUs));

            config.NewConfig<CreateOrUpdateAboutUsDto, AboutUs>()
                 .Map(dest => dest.Image,
                    src => FileHelper.Upload(src.Image, FileHelper.AboutUs));
        }
    }
}
