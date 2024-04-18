using Portfolio.Domain.Features.AboutSection.Dtos.About;

namespace Portfolio.Application.Features.AboutSection.Abstractions
{
    public interface IAboutUsService
    {
        Task<ResponseModel<AboutUsDto>> CreateOrUpdate(CreateOrUpdateAboutUsDto Dto);
        ResponseModel<AboutUsDto> Get();
    }
}