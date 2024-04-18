using Portfolio.Domain.Features.Products.Dtos.Details;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Validations
{
    internal class UpdateProductDetailsValidation : AbstractValidator<UpdateProductDetailsDto>
    {
        private readonly IGenericRepository<ProductDetails> _productDetailsRepo;

        public UpdateProductDetailsValidation(IGenericRepository<ProductDetails> productDetailsRepo)
        {
            _productDetailsRepo = productDetailsRepo;

            RuleFor(x => x).Custom((request, context) => IsValidTranslatableContents(request, context));

            RuleFor(x => x.Id)
                .MustAsync(IsExist)
                .WithMessage(Message.Error_Product_Not_Found);
        }
        private async Task<bool> IsExist(Guid ProductId, CancellationToken token)
            => await _productDetailsRepo.IsExist(x => x.Id == ProductId);

        private void IsValidTranslatableContents(UpdateProductDetailsDto request, ValidationContext<UpdateProductDetailsDto> context)
        {
            if (request.Content is not null && !request.Content.IsValid())
                context.AddFailure(nameof(request.Content), Message.Error_TranslatableContent);
        }
    }
}