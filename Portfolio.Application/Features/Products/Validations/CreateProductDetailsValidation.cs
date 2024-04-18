using Portfolio.Domain.Features.Products.Dtos.Details;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Validations
{
    internal class CreateProductDetailsValidation : AbstractValidator<CreateProductDetailsDto>
    {
        private readonly IGenericRepository<Product> _productRepo;

        public CreateProductDetailsValidation(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;

            RuleFor(x => x).Custom((request, context) => IsValidTranslatableContents(request, context));

            RuleFor(x => x.ProductId)
                .MustAsync(IsExist)
                .WithMessage(Message.Error_Product_Not_Found);
        }
        private async Task<bool> IsExist(Guid ProductId, CancellationToken token)
            => await _productRepo.IsExist(x => x.Id == ProductId);

        private void IsValidTranslatableContents(CreateProductDetailsDto request, ValidationContext<CreateProductDetailsDto> context)
        {
            if (!request.Content.IsValid())
                context.AddFailure(nameof(request.Content), Message.Error_TranslatableContent);
        }
    }
}