using Portfolio.Domain.Features.Products.Dtos.ExtraDetails;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Validations
{
    internal class CreateProductExtraDetailsValidation : AbstractValidator<CreateProductExtraDetailsDto>
    {
        private readonly IGenericRepository<Product> _productRepo;

        public CreateProductExtraDetailsValidation(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;

            RuleFor(x => x).Custom((request, context) => IsValidTranslatableContents(request, context));

            RuleFor(x => x.ProductId)
                .MustAsync(IsExist)
                .WithMessage(Message.Error_Product_Not_Found);
        }
        private async Task<bool> IsExist(Guid ProductId, CancellationToken token)
            => await _productRepo.IsExist(x => x.Id == ProductId);

        private void IsValidTranslatableContents(CreateProductExtraDetailsDto request, ValidationContext<CreateProductExtraDetailsDto> context)
        {
            if (!request.Title.IsValid())
                context.AddFailure(nameof(request.Title), Message.Error_TranslatableContent);

            if (!request.Description.IsValid())
                context.AddFailure(nameof(request.Description), Message.Error_TranslatableContent);
        }
    }
}