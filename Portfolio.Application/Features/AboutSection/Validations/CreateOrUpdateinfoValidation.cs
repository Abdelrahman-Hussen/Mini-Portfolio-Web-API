using Portfolio.Application.Features.AboutSection.Specifications;
using Portfolio.Domain.Features.AboutSection.Dtos.Infos;
using Portfolio.Domain.Features.AboutSection.Models;

namespace Portfolio.Application.Features.AboutSection.Validations
{
    internal class CreateOrUpdateInfoValidation : AbstractValidator<CreateOrUpdateInfoDto>
    {
        private readonly IGenericRepository<Info> _infoRepo;

        public CreateOrUpdateInfoValidation(IGenericRepository<Info> infoRepo)
        {
            _infoRepo = infoRepo;

            RuleFor(x => x).Custom((request, context) => IsExist(request, context));

            RuleFor(x => x).Custom((request, context) => IsValidTranslatableContents(request, context));
        }

        private void IsExist(CreateOrUpdateInfoDto request, ValidationContext<CreateOrUpdateInfoDto> context)
        {
            var result = _infoRepo.GetEntityWithSpec(InfoSpecification.Get());

            if (result is null && ((request.Title is null) || (request.Slogan is null)))
                context.AddFailure(nameof(Info), Message.Error_RequiredField);
        }

        private void IsValidTranslatableContents(CreateOrUpdateInfoDto request, ValidationContext<CreateOrUpdateInfoDto> context)
        {
            if (request.Title is not null && !request.Title.IsValid())
                context.AddFailure(nameof(request.Title), Message.Error_TranslatableContent);

            if (request.Slogan is not null && !request.Slogan.IsValid())
                context.AddFailure(nameof(request.Slogan), Message.Error_TranslatableContent);
        }
    }
}
