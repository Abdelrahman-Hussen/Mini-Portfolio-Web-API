using Portfolio.Domain.Features.Products.Dtos.Properties;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Validations
{
    internal class CreateProductPropertiesValidation : AbstractValidator<CreateProductPropertiesDto>
    {
        private readonly IGenericRepository<Product> _productRepo;

        public CreateProductPropertiesValidation(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;

            RuleFor(x => x).Custom((request, context) => IsValidTranslatableContents(request, context));

            RuleFor(x => x.ProductId)
                .MustAsync(IsExist)
                .WithMessage(Message.Error_Product_Not_Found);

            RuleFor(r => r.Type)
               .IsInEnum()
               .WithMessage(Message.Error_RequiredField);

            RuleFor(r => r.Value)
               .NotEmpty()
               .WithMessage(Message.Error_RequiredField);
        }
        private async Task<bool> IsExist(Guid ProductId, CancellationToken token)
            => await _productRepo.IsExist(x => x.Id == ProductId);

        private void IsValidTranslatableContents(CreateProductPropertiesDto request, ValidationContext<CreateProductPropertiesDto> context)
        {
            if (!request.Name.IsValid())
                context.AddFailure(nameof(request.Name), Message.Error_TranslatableContent);
        }
    }
}