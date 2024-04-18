using Portfolio.Application.Features.ContactSection.Abstractions;
using Portfolio.Application.Features.ContactSection.Specifications;
using Portfolio.Domain.Features.ContactSection.Dtos.ContactInfos;
using Portfolio.Domain.Features.ContactSection.Models;

namespace Portfolio.Application.Features.ContactSection.Services
{
    internal class ContactInfoService(IMapper _mapper,
                               IGenericRepository<ContactInfo> _contactInfoRepo,
                               IValidator<CreateOrUpdateContactInfoDto> _createOrUpdateValidation) : IContactInfoService
    {
        public ResponseModel<ContactInfoDto> Get()
        {
            var result = _contactInfoRepo.GetEntityWithSpec(ContactInfoSpecification.Get());

            if (result is null)
                throw new NotFoundException(Message.Error_NotFound);

            var contactInfo = _mapper.Map<ContactInfoDto>(result);

            return ResponseModel<ContactInfoDto>.Success(contactInfo);
        }

        public async Task<ResponseModel<ContactInfoDto>> CreateOrUpdate(CreateOrUpdateContactInfoDto Dto)
        {
            var validationResult = await _createOrUpdateValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var result = _contactInfoRepo.GetEntityWithSpec(ContactInfoSpecification.Get());

            if (result is null)
            {
                var contactInfo = _mapper.Map<ContactInfo>(Dto);

                await _contactInfoRepo.Add(_mapper.Map<ContactInfo>(Dto));
                await _contactInfoRepo.Save();

                return ResponseModel<ContactInfoDto>.Success(_mapper.Map<ContactInfoDto>(contactInfo));
            }
            else
            {
                result.Update(Dto);
                await _contactInfoRepo.Save();

                return ResponseModel<ContactInfoDto>.Success(_mapper.Map<ContactInfoDto>(result));
            }
        }
    }
}
