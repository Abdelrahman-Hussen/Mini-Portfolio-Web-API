using Portfolio.Domain.Features.AboutSection.Dtos.Infos;
using Portfolio.Domain.Features.AboutSection.Models;
using Mapster;

namespace Portfolio.Application.Features.AboutSection.Mapping
{
    internal class InfoMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Info, InfoDto>()
                 .Map(dest => dest.Title,
                    src => src.Title.GetCulturedValue())
                 .Map(dest => dest.Slogan,
                    src => src.Slogan.GetCulturedValue());
        }
    }
}