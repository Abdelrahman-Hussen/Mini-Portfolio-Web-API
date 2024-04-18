using Portfolio.Domain.Features.Products.Dtos.Products;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Validations
{
    internal class UpdateProductValidation : AbstractValidator<UpdateProductDto>
    {
        private readonly IGenericRepository<Product> _productRepo;

        public UpdateProductValidation(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;

            RuleFor(x => x).Custom((request, context) => IsValidTranslatableContents(request, context));

            RuleFor(x => x.Id)
                .MustAsync(IsExist)
                .WithMessage(Message.Error_Category_Not_Found);

            RuleFor(r => r.Price)
               .GreaterThan(0);


            RuleFor(x => x).Custom((request, context) => IsValidImage(request, context));
        }

        private async Task<bool> IsExist(Guid Id, CancellationToken token)
            => await _productRepo.IsExist(x => x.Id == Id);

        private void IsValidTranslatableContents(UpdateProductDto request, ValidationContext<UpdateProductDto> context)
        {
            if (request.Name is not null && !request.Name.IsValid())
                context.AddFailure(nameof(request.Name), Message.Error_TranslatableContent);
        }

        private void IsValidImage(UpdateProductDto request, ValidationContext<UpdateProductDto> context)
        {
            if (request.Images is null)
                return;

            foreach (var image in request.Images)
            {
                if (!FileHelper.IsValidImage(image))
                {
                    context.AddFailure(nameof(request.Images), Message.Error_NotSupportedExtantion);
                    return;
                }
            }
        }
    }
}
