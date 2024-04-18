using Portfolio.Application.Features.Products.Abstractions;
using Portfolio.Application.Features.Products.Specifications;
using Portfolio.Domain.Features.Products.Dtos.Details;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Services
{
    internal class ProductDetailsService(IMapper _mapper,
                                 IGenericRepository<ProductDetails> _productDetailsRepo,
                                 IValidator<CreateProductDetailsDto> _createProductDetailsValidation,
                                 IValidator<UpdateProductDetailsDto> _updateProductDetailsValidation) : IProductDetailsService
    {
        public ResponseModel<List<ProductDetailsDto>> Get(ProductDetailsRequestModel requestModel)
        {
            var result = _productDetailsRepo.GetWithSpec(ProductDetailsSpecification.GetAll(requestModel));

            var productDetails = _mapper.Map<List<ProductDetailsDto>>(result.data);

            return ResponseModel<List<ProductDetailsDto>>.Success(productDetails);
        }

        public ResponseModel<ProductDetailsDto> GetById(Guid Id)
        {
            var result = _productDetailsRepo.GetEntityWithSpec(ProductDetailsSpecification.GetById(Id));

            if (result == null)
                throw new NotFoundException(Message.Error_NotFound);

            var productDetails = _mapper.Map<ProductDetailsDto>(result);

            return ResponseModel<ProductDetailsDto>.Success(productDetails);
        }

        public async Task<ResponseModel<ProductDetailsDto>> Create(CreateProductDetailsDto Dto)
        {
            var validationResult = await _createProductDetailsValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var productDetails = _mapper.Map<ProductDetails>(Dto);

            await _productDetailsRepo.Add(productDetails);
            await _productDetailsRepo.Save();

            return ResponseModel<ProductDetailsDto>.Success(_mapper.Map<ProductDetailsDto>(productDetails));
        }

        public async Task<ResponseModel<ProductDetailsDto>> Update(UpdateProductDetailsDto Dto)
        {
            var validationResult = await _updateProductDetailsValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var productDetails = await _productDetailsRepo.GetById(Dto.Id);

            productDetails!.Update(Dto);

            _productDetailsRepo.Update(productDetails);

            await _productDetailsRepo.Save();

            return ResponseModel<ProductDetailsDto>.Success(_mapper.Map<ProductDetailsDto>(productDetails));
        }

        public async Task<ResponseModel<string>> Delete(Guid id)
        {
            var productDetails = await _productDetailsRepo.GetById(id);

            if (productDetails == null)
                throw new NotFoundException(Message.Error_NotFound);

            _productDetailsRepo.Delete(productDetails);

            await _productDetailsRepo.Save();

            return ResponseModel<string>.Success();
        }
    }
}
