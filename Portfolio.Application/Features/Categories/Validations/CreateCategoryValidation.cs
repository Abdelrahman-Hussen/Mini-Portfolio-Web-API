using Portfolio.Domain.Features.Categories.Dtos;

namespace Portfolio.Application.Features.Categories.Validations
{
    internal class CreateCategoryValidation : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidation()
        {
            RuleFor(x => x).Custom((request, context) => IsValidTranslatableContents(request, context));

            RuleFor(r => r.Image)
               .NotEmpty()
               .WithMessage(Message.Error_RequiredField)
               .Must(IsValidImage)
               .WithMessage(Message.Error_NotSupportedExtantion);
        }
        private void IsValidTranslatableContents(CreateCategoryDto request, ValidationContext<CreateCategoryDto> context)
        {
            if (!request.Name.IsValid())
                context.AddFailure(nameof(request.Name), Message.Error_TranslatableContent);

            if (!request.Description.IsValid())
                context.AddFailure(nameof(request.Description), Message.Error_TranslatableContent);
        }
        private bool IsValidImage(IFormFile image)
            => FileHelper.IsValidImage(image);
    }
}
