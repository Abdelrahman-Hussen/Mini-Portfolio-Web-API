using Portfolio.Domain.Features.ContactSection.Dtos.SocailMeadias;

namespace Portfolio.Application.Features.ContactSection.Abstractions
{
    public interface ISocialMediaService
    {
        Task<ResponseModel<SocialMediaDto>> CreateOrUpdate(CreateOrUpdateSocialMediaDto Dto);
        ResponseModel<SocialMediaDto> Get();
    }
}