using Portfolio.Application.Features.Products.Abstractions;
using Portfolio.Application.Features.Products.Specifications;
using Portfolio.Domain.Features.Products.Dtos.ExtraDetails;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Services
{
    internal class ProductExtraDetailsService(IMapper _mapper,
                                 IGenericRepository<ProductExtraDetails> _productExtraDetailsRepo,
                                 IValidator<CreateProductExtraDetailsDto> _createProductExtraDetailsValidation,
                                 IValidator<UpdateProductExtraDetailsDto> _updateProductExtraDetailsValidation) : IProductExtraDetailsService
    {
        public ResponseModel<List<ProductExtraDetailsDto>> Get(ProductExtraDetailsRequestModel requestModel)
        {
            var result = _productExtraDetailsRepo.GetWithSpec(ProductExtraDetailsSpecification.GetAll(requestModel));

            var productExtraDetails = _mapper.Map<List<ProductExtraDetailsDto>>(result.data);

            return ResponseModel<List<ProductExtraDetailsDto>>.Success(productExtraDetails);
        }

        public ResponseModel<ProductExtraDetailsDto> GetById(Guid Id)
        {
            var result = _productExtraDetailsRepo.GetEntityWithSpec(ProductExtraDetailsSpecification.GetById(Id));

            if (result == null)
                throw new NotFoundException(Message.Error_NotFound);

            var productExtraDetails = _mapper.Map<ProductExtraDetailsDto>(result);

            return ResponseModel<ProductExtraDetailsDto>.Success(productExtraDetails);
        }

        public async Task<ResponseModel<ProductExtraDetailsDto>> Create(CreateProductExtraDetailsDto Dto)
        {
            var validationResult = await _createProductExtraDetailsValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var productExtraDetails = _mapper.Map<ProductExtraDetails>(Dto);

            await _productExtraDetailsRepo.Add(productExtraDetails);
            await _productExtraDetailsRepo.Save();

            return ResponseModel<ProductExtraDetailsDto>.Success(_mapper.Map<ProductExtraDetailsDto>(productExtraDetails));
        }

        public async Task<ResponseModel<ProductExtraDetailsDto>> Update(UpdateProductExtraDetailsDto Dto)
        {
            var validationResult = await _updateProductExtraDetailsValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var productExtraDetails = await _productExtraDetailsRepo.GetById(Dto.Id);

            productExtraDetails!.Update(Dto);

            _productExtraDetailsRepo.Update(productExtraDetails);

            await _productExtraDetailsRepo.Save();

            return ResponseModel<ProductExtraDetailsDto>.Success(_mapper.Map<ProductExtraDetailsDto>(productExtraDetails));
        }

        public async Task<ResponseModel<string>> Delete(Guid id)
        {
            var productExtraDetails = await _productExtraDetailsRepo.GetById(id);

            if (productExtraDetails == null)
                throw new NotFoundException(Message.Error_NotFound);

            _productExtraDetailsRepo.Delete(productExtraDetails);

            await _productExtraDetailsRepo.Save();

            return ResponseModel<string>.Success();
        }
    }
}
