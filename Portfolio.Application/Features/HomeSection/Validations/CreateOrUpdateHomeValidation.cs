using Portfolio.Application.Features.HomeSection.Specifications;
using Portfolio.Domain.Features.HomeSection.Dtos;
using Portfolio.Domain.Features.HomeSection.Models;

namespace Portfolio.Application.Features.HomeSection.Validations
{
    internal class CreateOrUpdateHomeValidation : AbstractValidator<CreateOrUpdateHomeDto>
    {
        private readonly IGenericRepository<Home> _homeRepo;

        public CreateOrUpdateHomeValidation(IGenericRepository<Home> homeRepo)
        {
            _homeRepo = homeRepo;

            RuleFor(x => x).Custom((request, context) => IsExist(request, context));

            RuleFor(x => x).Custom((request, context) => IsValidTranslatableContents(request, context));

            RuleFor(x => x).Custom((request, context) => IsValidImage(request, context));
        }

        private void IsExist(CreateOrUpdateHomeDto request, ValidationContext<CreateOrUpdateHomeDto> context)
        {
            var result = _homeRepo.GetEntityWithSpec(HomeSpecification.Get());

            if (result is null && ((request.Header is null) || (request.SubHeader is null) || (request.Description is null)))
                context.AddFailure(nameof(Home), Message.Error_RequiredField);
        }

        private void IsValidImage(CreateOrUpdateHomeDto request, ValidationContext<CreateOrUpdateHomeDto> context)
        {
            if (request.Video is not null && !FileHelper.IsValidVideo(request.Video))
                context.AddFailure(nameof(request.Video), Message.Error_NotSupportedExtantion);
        }

        private void IsValidTranslatableContents(CreateOrUpdateHomeDto request, ValidationContext<CreateOrUpdateHomeDto> context)
        {
            if (request.Header is not null && !request.Header.IsValid())
                context.AddFailure(nameof(request.Header), Message.Error_TranslatableContent);

            if (request.SubHeader is not null && !request.SubHeader.IsValid())
                context.AddFailure(nameof(request.SubHeader), Message.Error_TranslatableContent);

            if (request.Description is not null && !request.Description.IsValid())
                context.AddFailure(nameof(request.Description), Message.Error_TranslatableContent);
        }
    }
}
