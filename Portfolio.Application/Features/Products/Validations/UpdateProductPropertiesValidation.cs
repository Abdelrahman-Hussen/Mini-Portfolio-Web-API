using Portfolio.Domain.Features.Products.Dtos.Properties;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Validations
{
    internal class UpdateProductPropertiesValidation : AbstractValidator<UpdateProductPropertiesDto>
    {
        private readonly IGenericRepository<ProductProperties> _productPropertiesRepo;

        public UpdateProductPropertiesValidation(IGenericRepository<ProductProperties> productPropertiesRepo)
        {
            _productPropertiesRepo = productPropertiesRepo;

            RuleFor(x => x).Custom((request, context) => IsValidTranslatableContents(request, context));

            RuleFor(x => x.Id)
                .MustAsync(IsExist)
                .WithMessage(Message.Error_Product_Not_Found);
        }
        private async Task<bool> IsExist(Guid ProductId, CancellationToken token)
            => await _productPropertiesRepo.IsExist(x => x.Id == ProductId);

        private void IsValidTranslatableContents(UpdateProductPropertiesDto request, ValidationContext<UpdateProductPropertiesDto> context)
        {
            if (request.Name is not null && !request.Name.IsValid())
                context.AddFailure(nameof(request.Name), Message.Error_TranslatableContent);
        }
    }
}