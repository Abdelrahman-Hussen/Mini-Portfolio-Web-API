using Portfolio.Domain.Features.ContactSection.Dtos.SocailMeadias;
using Portfolio.Domain.Features.ContactSection.Models;

namespace Portfolio.Application.Features.ContactSection.Validations
{
    internal class CreateOrUpdateSocialMediaValidation : AbstractValidator<CreateOrUpdateSocialMediaDto>
    {
        private readonly IGenericRepository<SocialMedia> _socialMediaRepo;

        public CreateOrUpdateSocialMediaValidation(IGenericRepository<SocialMedia> homeRepo)
        {
            _socialMediaRepo = homeRepo;

            RuleFor(x => x).Custom((request, context) => IsExist(request, context));
        }

        private void IsExist(CreateOrUpdateSocialMediaDto request, ValidationContext<CreateOrUpdateSocialMediaDto> context)
        {

        }
    }
}
