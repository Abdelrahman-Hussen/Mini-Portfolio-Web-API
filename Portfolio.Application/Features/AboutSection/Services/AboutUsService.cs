using Portfolio.Application.Features.AboutSection.Abstractions;
using Portfolio.Application.Features.AboutSection.Specifications;
using Portfolio.Domain.Features.AboutSection.Dtos.About;
using Portfolio.Domain.Features.AboutSection.Models;

namespace Portfolio.Application.Features.AboutSection.Services
{
    internal class AboutUsService(IMapper _mapper,
                               IGenericRepository<AboutUs> _aboutUsRepo,
                               IValidator<CreateOrUpdateAboutUsDto> _createOrUpdateValidation) : IAboutUsService
    {
        public ResponseModel<AboutUsDto> Get()
        {
            var result = _aboutUsRepo.GetEntityWithSpec(AboutUsSpecification.Get());

            if (result is null)
                throw new NotFoundException(Message.Error_NotFound);

            var aboutUs = _mapper.Map<AboutUsDto>(result);

            return ResponseModel<AboutUsDto>.Success(aboutUs);
        }

        public async Task<ResponseModel<AboutUsDto>> CreateOrUpdate(CreateOrUpdateAboutUsDto Dto)
        {
            var validationResult = await _createOrUpdateValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var result = _aboutUsRepo.GetEntityWithSpec(AboutUsSpecification.Get());

            if (result is null)
            {
                var aboutUs = _mapper.Map<AboutUs>(Dto);

                await _aboutUsRepo.Add(_mapper.Map<AboutUs>(Dto));
                await _aboutUsRepo.Save();

                return ResponseModel<AboutUsDto>.Success(_mapper.Map<AboutUsDto>(aboutUs));
            }
            else
            {
                result.Update(Dto);
                await _aboutUsRepo.Save();

                return ResponseModel<AboutUsDto>.Success(_mapper.Map<AboutUsDto>(result));
            }
        }
    }
}
