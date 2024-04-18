using Portfolio.Domain.Features.ReviewsSection.Dtos;

namespace Portfolio.Application.Features.ReviewsSection.Validations
{
    internal class CreateReviewValidation : AbstractValidator<CreateReviewDto>
    {
        public CreateReviewValidation()
        {

            RuleFor(r => r.ReviewerName)
               .NotEmpty()
               .WithMessage(Message.Error_RequiredField);

            RuleFor(r => r.ReviewerTitle)
               .NotEmpty()
               .WithMessage(Message.Error_RequiredField);

            RuleFor(r => r.Content)
               .NotEmpty()
               .WithMessage(Message.Error_RequiredField);

            RuleFor(r => r.ReviewerImage)
               .NotEmpty()
               .WithMessage(Message.Error_RequiredField)
               .MustAsync(IsValidImage)
               .WithMessage(Message.Error_NotSupportedExtantion);
        }
        private async Task<bool> IsValidImage(IFormFile image, CancellationToken cancellationToken)
            => FileHelper.IsValidImage(image);
    }
}
