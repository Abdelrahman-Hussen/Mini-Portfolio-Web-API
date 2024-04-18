using Portfolio.Domain.Features.ContactSection.Dtos.ContactUsForm;

namespace Portfolio.Application.Features.ContactSection.Validations
{
    internal class CreateContactUsValidation : AbstractValidator<CreateContactUsDto>
    {
        public CreateContactUsValidation()
        {

            RuleFor(r => r.FullName)
               .NotEmpty()
               .WithMessage(Message.Error_RequiredField);

            RuleFor(r => r.Email)
               .NotEmpty()
               .WithMessage(Message.Error_RequiredField)
               .EmailAddress();

            RuleFor(r => r.PhoneNumber)
               .NotEmpty()
               .WithMessage(Message.Error_RequiredField);

            RuleFor(r => r.Message)
               .NotEmpty()
               .WithMessage(Message.Error_RequiredField);
        }
    }
}
