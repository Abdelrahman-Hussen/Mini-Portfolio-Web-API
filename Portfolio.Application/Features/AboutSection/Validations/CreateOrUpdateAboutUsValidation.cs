using Portfolio.Application.Features.AboutSection.Specifications;
using Portfolio.Domain.Features.AboutSection.Dtos.About;
using Portfolio.Domain.Features.AboutSection.Models;

namespace Portfolio.Application.Features.AboutSection.Validations
{
    internal class CreateOrUpdateAboutUsValidation : AbstractValidator<CreateOrUpdateAboutUsDto>
    {
        private readonly IGenericRepository<AboutUs> _aboutUsRepo;

        public CreateOrUpdateAboutUsValidation(IGenericRepository<AboutUs> aboutUsRepo)
        {
            _aboutUsRepo = aboutUsRepo;

            RuleFor(x => x).Custom((request, context) => IsExist(request, context));

            RuleFor(x => x).Custom((request, context) => IsValidTranslatableContents(request, context));

            RuleFor(x => x).Custom((request, context) => IsValidImage(request, context));
        }

        private void IsExist(CreateOrUpdateAboutUsDto request, ValidationContext<CreateOrUpdateAboutUsDto> context)
        {
            var result = _aboutUsRepo.GetEntityWithSpec(AboutUsSpecification.Get());

            if (result is null && ((request.Header is null) || (request.Description is null)))
                context.AddFailure(nameof(AboutUs), Message.Error_RequiredField);
        }

        private void IsValidImage(CreateOrUpdateAboutUsDto request, ValidationContext<CreateOrUpdateAboutUsDto> context)
        {
            if (request.Image is not null && !FileHelper.IsValidImage(request.Image))
                context.AddFailure(nameof(request.Image), Message.Error_NotSupportedExtantion);
        }

        private void IsValidTranslatableContents(CreateOrUpdateAboutUsDto request, ValidationContext<CreateOrUpdateAboutUsDto> context)
        {
            if (request.Header is not null && !request.Header.IsValid())
                context.AddFailure(nameof(request.Header), Message.Error_TranslatableContent);

            if (request.Description is not null && !request.Description.IsValid())
                context.AddFailure(nameof(request.Description), Message.Error_TranslatableContent);
        }
    }
}
