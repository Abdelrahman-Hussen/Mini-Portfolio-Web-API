using Portfolio.Domain.Features.ReviewsSection.Dtos;
using Portfolio.Domain.Features.ReviewsSection.Models;
using Portfolio.Infrastructure.Reposatory;

namespace Portfolio.Application.Features.ReviewsSection.Validations
{
    internal class UpdateReviewValidation : AbstractValidator<UpdateReviewDto>
    {
        private readonly IGenericRepository<Review> reviewRepo;

        public UpdateReviewValidation(IGenericRepository<Review> _reviewRepo)
        {
            reviewRepo = _reviewRepo;

            RuleFor(x => x).Custom((request, context) => IsValidImage(request, context));
        }

        private void IsValidImage(UpdateReviewDto request, ValidationContext<UpdateReviewDto> context)
        {
            if (request.ReviewerImage is not null && !FileHelper.IsValidImage(request.ReviewerImage))
                context.AddFailure(nameof(request.ReviewerImage), Message.Error_NotSupportedExtantion);
        }
    }
}
