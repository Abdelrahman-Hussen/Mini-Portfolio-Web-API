using Portfolio.Domain.Features.Products.Dtos.ExtraDetails;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Validations
{
    internal class UpdateProductExtraDetailsValidation : AbstractValidator<UpdateProductExtraDetailsDto>
    {
        private readonly IGenericRepository<ProductExtraDetails> _productExtraDetailsRepo;

        public UpdateProductExtraDetailsValidation(IGenericRepository<ProductExtraDetails> productDetailsRepo)
        {
            _productExtraDetailsRepo = productDetailsRepo;

            RuleFor(x => x).Custom((request, context) => IsValidTranslatableContents(request, context));

            RuleFor(x => x.Id)
                .MustAsync(IsExist)
                .WithMessage(Message.Error_Product_Not_Found);
        }
        private async Task<bool> IsExist(Guid ProductId, CancellationToken token)
            => await _productExtraDetailsRepo.IsExist(x => x.Id == ProductId);

        private void IsValidTranslatableContents(UpdateProductExtraDetailsDto request, ValidationContext<UpdateProductExtraDetailsDto> context)
        {
            if (request.Title is not null && !request.Title.IsValid())
                context.AddFailure(nameof(request.Title), Message.Error_TranslatableContent);

            if (request.Description is not null && !request.Description.IsValid())
                context.AddFailure(nameof(request.Description), Message.Error_TranslatableContent);
        }
    }
}