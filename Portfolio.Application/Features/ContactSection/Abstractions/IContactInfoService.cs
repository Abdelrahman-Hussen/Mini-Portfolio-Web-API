using Portfolio.Domain.Features.ContactSection.Dtos.ContactInfos;

namespace Portfolio.Application.Features.ContactSection.Abstractions
{
    public interface IContactInfoService
    {
        Task<ResponseModel<ContactInfoDto>> CreateOrUpdate(CreateOrUpdateContactInfoDto Dto);
        ResponseModel<ContactInfoDto> Get();
    }
}