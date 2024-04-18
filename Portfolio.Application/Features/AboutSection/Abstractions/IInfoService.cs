using Portfolio.Domain.Features.AboutSection.Dtos.Infos;

namespace Portfolio.Application.Features.AboutSection.Abstractions
{
    public interface IInfoService
    {
        Task<ResponseModel<InfoDto>> CreateOrUpdate(CreateOrUpdateInfoDto Dto);
        ResponseModel<InfoDto> Get();
    }
}