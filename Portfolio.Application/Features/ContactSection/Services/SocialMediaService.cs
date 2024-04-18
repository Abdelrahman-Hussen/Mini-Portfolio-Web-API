using Portfolio.Application.Features.ContactSection.Abstractions;
using Portfolio.Application.Features.ContactSection.Specifications;
using Portfolio.Domain.Features.ContactSection.Dtos.SocailMeadias;
using Portfolio.Domain.Features.ContactSection.Models;

namespace Portfolio.Application.Features.ContactSection.Services
{
    internal class SocialMediaService(IMapper _mapper,
                               IGenericRepository<SocialMedia> _socialMediaRepo,
                               IValidator<CreateOrUpdateSocialMediaDto> _createOrUpdateValidation) : ISocialMediaService
    {
        public ResponseModel<SocialMediaDto> Get()
        {
            var result = _socialMediaRepo.GetEntityWithSpec(SocialMediaSpecification.Get());

            if (result is null)
                throw new NotFoundException(Message.Error_NotFound);

            var socialMedia = _mapper.Map<SocialMediaDto>(result);

            return ResponseModel<SocialMediaDto>.Success(socialMedia);
        }

        public async Task<ResponseModel<SocialMediaDto>> CreateOrUpdate(CreateOrUpdateSocialMediaDto Dto)
        {
            var validationResult = await _createOrUpdateValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var result = _socialMediaRepo.GetEntityWithSpec(SocialMediaSpecification.Get());

            if (result is null)
            {
                var socialMedia = _mapper.Map<SocialMedia>(Dto);

                await _socialMediaRepo.Add(_mapper.Map<SocialMedia>(Dto));
                await _socialMediaRepo.Save();

                return ResponseModel<SocialMediaDto>.Success(_mapper.Map<SocialMediaDto>(socialMedia));
            }
            else
            {
                result.Update(Dto);
                await _socialMediaRepo.Save();

                return ResponseModel<SocialMediaDto>.Success(_mapper.Map<SocialMediaDto>(result));
            }
        }
    }
}
