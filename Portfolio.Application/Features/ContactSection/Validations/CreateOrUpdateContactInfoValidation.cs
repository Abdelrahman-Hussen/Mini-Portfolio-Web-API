using Portfolio.Application.Features.ContactSection.Specifications;
using Portfolio.Domain.Features.ContactSection.Dtos.ContactInfos;
using Portfolio.Domain.Features.ContactSection.Models;

namespace Portfolio.Application.Features.ContactSection.Validations
{
    internal class CreateOrUpdateContactInfoValidation : AbstractValidator<CreateOrUpdateContactInfoDto>
    {
        private readonly IGenericRepository<ContactInfo> _contactInfoRepo;

        public CreateOrUpdateContactInfoValidation(IGenericRepository<ContactInfo> homeRepo)
        {
            _contactInfoRepo = homeRepo;

            RuleFor(x => x).Custom((request, context) => IsExist(request, context));
        }

        private void IsExist(CreateOrUpdateContactInfoDto request, ValidationContext<CreateOrUpdateContactInfoDto> context)
        {
            var result = _contactInfoRepo.GetEntityWithSpec(ContactInfoSpecification.Get());

            if (result is null && ((request.Email is null) || (request.Phone is null) || (request.FAX is null)))
                context.AddFailure(nameof(ContactInfo), Message.Error_RequiredField);
        }
    }
}
