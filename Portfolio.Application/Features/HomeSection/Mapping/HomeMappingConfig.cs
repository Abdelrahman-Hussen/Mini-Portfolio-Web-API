using Portfolio.Domain.Features.HomeSection.Dtos;
using Portfolio.Domain.Features.HomeSection.Models;
using Mapster;

namespace Portfolio.Application.Features.HomeSection.Mapping
{
    internal class HomeMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Home, HomeDto>()
                 .Map(dest => dest.Header,
                    src => src.Header.GetCulturedValue())
                 .Map(dest => dest.SubHeader,
                    src => src.SubHeader.GetCulturedValue())
                 .Map(dest => dest.Description,
                    src => src.Description.GetCulturedValue())
                 .Map(dest => dest.Video,
                    src => src.Video.MappFile(FileHelper.Home));

            config.NewConfig<CreateOrUpdateHomeDto, Home>()
                 .Map(dest => dest.Video,
                    src => FileHelper.Upload(src.Video, FileHelper.Home));
        }
    }
}
