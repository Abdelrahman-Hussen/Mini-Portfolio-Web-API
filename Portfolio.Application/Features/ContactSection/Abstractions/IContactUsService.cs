using Portfolio.Domain.Features.ContactSection.Dtos.ContactUsForm;

namespace Portfolio.Application.Features.ContactSection.Abstractions
{
    public interface IContactUsService
    {
        Task<ResponseModel<ContactUsDto>> Create(CreateContactUsDto Dto);
        Task<ResponseModel<string>> Delete(Guid id);
        ResponseModel<List<ContactUsDto>> Get(RequestModel requestModel);
        ResponseModel<ContactUsDto> GetById(Guid Id);
    }
}