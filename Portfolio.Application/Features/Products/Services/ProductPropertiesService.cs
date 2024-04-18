using Portfolio.Application.Features.Products.Abstractions;
using Portfolio.Application.Features.Products.Specifications;
using Portfolio.Domain.Features.Products.Dtos.Properties;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Services
{
    internal class ProductPropertiesService(IMapper _mapper,
                                 IGenericRepository<ProductProperties> _productPropertiesRepo,
                                 IValidator<CreateProductPropertiesDto> _createProductPropertiesValidation,
                                 IValidator<UpdateProductPropertiesDto> _updateProductPropertiesValidation) : IProductPropertiesService
    {
        public ResponseModel<List<ProductPropertiesDto>> Get(ProductPropertiesRequestModel requestModel)
        {
            var result = _productPropertiesRepo.GetWithSpec(ProductPropertiesSpecification.GetAll(requestModel));

            var productProperties = _mapper.Map<List<ProductPropertiesDto>>(result.data);

            return ResponseModel<List<ProductPropertiesDto>>.Success(productProperties);
        }

        public ResponseModel<ProductPropertiesDto> GetById(Guid Id)
        {
            var result = _productPropertiesRepo.GetEntityWithSpec(ProductPropertiesSpecification.GetById(Id));

            if (result == null)
                throw new NotFoundException(Message.Error_NotFound);

            var productProperties = _mapper.Map<ProductPropertiesDto>(result);

            return ResponseModel<ProductPropertiesDto>.Success(productProperties);
        }

        public async Task<ResponseModel<ProductPropertiesDto>> Create(CreateProductPropertiesDto Dto)
        {
            var validationResult = await _createProductPropertiesValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var productProperties = _mapper.Map<ProductProperties>(Dto);

            await _productPropertiesRepo.Add(productProperties);
            await _productPropertiesRepo.Save();

            return ResponseModel<ProductPropertiesDto>.Success(_mapper.Map<ProductPropertiesDto>(productProperties));
        }

        public async Task<ResponseModel<ProductPropertiesDto>> Update(UpdateProductPropertiesDto Dto)
        {
            var validationResult = await _updateProductPropertiesValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var productProperties = await _productPropertiesRepo.GetById(Dto.Id);

            productProperties!.Update(Dto);

            _productPropertiesRepo.Update(productProperties);

            await _productPropertiesRepo.Save();

            return ResponseModel<ProductPropertiesDto>.Success(_mapper.Map<ProductPropertiesDto>(productProperties));
        }

        public async Task<ResponseModel<string>> Delete(Guid id)
        {
            var productProperties = await _productPropertiesRepo.GetById(id);

            if (productProperties == null)
                throw new NotFoundException(Message.Error_NotFound);

            _productPropertiesRepo.Delete(productProperties);

            await _productPropertiesRepo.Save();

            return ResponseModel<string>.Success();
        }
    }
}
