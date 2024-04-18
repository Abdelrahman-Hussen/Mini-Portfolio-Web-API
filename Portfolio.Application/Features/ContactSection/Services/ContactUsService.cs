using Portfolio.Application.Features.ContactSection.Abstractions;
using Portfolio.Application.Features.ContactSection.Specifications;
using Portfolio.Domain.Features.ContactSection.Dtos.ContactUsForm;
using Portfolio.Domain.Features.ContactSection.Models;

namespace Portfolio.Application.Features.ContactSection.Services
{
    internal class ContactUsService(IMapper _mapper,
                                 IGenericRepository<ContactUs> _contactUsRepo,
                                 IValidator<CreateContactUsDto> _createContactUsValidation) : IContactUsService
    {
        public ResponseModel<List<ContactUsDto>> Get(RequestModel requestModel)
        {
            var result = _contactUsRepo.GetWithSpec(ContactUsSpecification.GetAll(requestModel));

            var contactUs = _mapper.Map<List<ContactUsDto>>(result.data);

            return ResponseModel<List<ContactUsDto>>.Success(contactUs);
        }

        public ResponseModel<ContactUsDto> GetById(Guid Id)
        {
            var result = _contactUsRepo.GetEntityWithSpec(ContactUsSpecification.GetById(Id));

            if (result == null)
                throw new NotFoundException(Message.Error_NotFound);

            var contactUs = _mapper.Map<ContactUsDto>(result);

            return ResponseModel<ContactUsDto>.Success(contactUs);
        }

        public async Task<ResponseModel<ContactUsDto>> Create(CreateContactUsDto Dto)
        {
            var validationResult = await _createContactUsValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var contactUs = _mapper.Map<ContactUs>(Dto);

            await _contactUsRepo.Add(contactUs);
            await _contactUsRepo.Save();

            return ResponseModel<ContactUsDto>.Success(_mapper.Map<ContactUsDto>(contactUs));
        }

        public async Task<ResponseModel<string>> Delete(Guid id)
        {
            var contactUs = await _contactUsRepo.GetById(id);

            if (contactUs == null)
                throw new NotFoundException(Message.Error_NotFound);

            _contactUsRepo.Delete(contactUs);

            await _contactUsRepo.Save();

            return ResponseModel<string>.Success();
        }
    }
}
