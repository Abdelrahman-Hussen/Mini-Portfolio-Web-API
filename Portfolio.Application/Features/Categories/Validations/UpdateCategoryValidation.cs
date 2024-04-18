using Portfolio.Domain.Features.Categories.Dtos;
using Portfolio.Domain.Features.Categories.Models;

namespace Portfolio.Application.Features.Categories.Validations
{
    internal class UpdateCategoryValidation : AbstractValidator<UpdateCategoryDto>
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        public UpdateCategoryValidation(IGenericRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;

            RuleFor(x => x.Id)
                .MustAsync(IsExist)
                .WithMessage(Message.Error_NotFound);

            RuleFor(x => x).Custom((request, context) => IsValidTranslatableContents(request, context));

            RuleFor(x => x).Custom((request, context) => IsValidImage(request, context));
        }

        private async Task<bool> IsExist(Guid Id, CancellationToken token)
            => await _categoryRepo.IsExist(x => x.Id == Id);

        private void IsValidTranslatableContents(UpdateCategoryDto request, ValidationContext<UpdateCategoryDto> context)
        {
            if (request.Name is not null && !request.Name.IsValid())
                context.AddFailure(nameof(request.Name), Message.Error_TranslatableContent);

            if (request.Description is not null && !request.Description.IsValid())
                context.AddFailure(nameof(request.Description), Message.Error_TranslatableContent);
        }

        private void IsValidImage(UpdateCategoryDto request, ValidationContext<UpdateCategoryDto> context)
        {
            if (request.Image is null)
                return;

            if (!FileHelper.IsValidImage(request.Image))
                context.AddFailure(nameof(request.Image), Message.Error_NotSupportedExtantion);
        }
    }
}
