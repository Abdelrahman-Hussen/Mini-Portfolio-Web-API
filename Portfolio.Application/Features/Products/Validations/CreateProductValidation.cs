using Portfolio.Domain.Features.Categories.Models;
using Portfolio.Domain.Features.Products.Dtos.Products;

namespace Portfolio.Application.Features.Products.Validations
{
    internal class CreateProductValidation : AbstractValidator<CreateProductDto>
    {
        private readonly IGenericRepository<Category> _categoryRepo;

        public CreateProductValidation(IGenericRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;

            RuleFor(x => x).Custom((request, context) => IsValidTranslatableContents(request, context));

            RuleFor(x => x.CategoryId)
                .MustAsync(IsExist)
                .WithMessage(Message.Error_Category_Not_Found);

            RuleFor(r => r.Price)
               .NotEmpty()
               .WithMessage(Message.Error_RequiredField)
               .GreaterThan(0);

            RuleFor(r => r.Barcode)
               .NotEmpty()
               .WithMessage(Message.Error_RequiredField);

            RuleFor(r => r.Images)
               .NotEmpty()
               .WithMessage(Message.Error_RequiredField)
               .MustAsync(IsValidImage)
               .WithMessage(Message.Error_NotSupportedExtantion);
        }
        private async Task<bool> IsExist(Guid CategoryId, CancellationToken token)
            => await _categoryRepo.IsExist(x => x.Id == CategoryId);

        private void IsValidTranslatableContents(CreateProductDto request, ValidationContext<CreateProductDto> context)
        {
            if (!request.Name.IsValid())
                context.AddFailure(nameof(request.Name), Message.Error_TranslatableContent);
        }
        private async Task<bool> IsValidImage(List<IFormFile> images, CancellationToken cancellationToken)
        {
            foreach (var image in images)
            {
                if (!FileHelper.IsValidImage(image))
                    return false;
            }
            return true;
        }
    }
}
