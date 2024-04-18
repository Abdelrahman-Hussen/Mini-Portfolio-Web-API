using Portfolio.Application.Features.Products.Abstractions;
using Portfolio.Application.Features.Products.Specifications;
using Portfolio.Domain.Features.Products.Dtos.Products;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Services
{
    internal class ProductService(IMapper _mapper,
                                 IGenericRepository<Product> _productRepo,
                                 IValidator<CreateProductDto> _createProductValidation,
                                 IValidator<UpdateProductDto> _updateProductValidation) : IProductService
    {
        public ResponseModel<List<ProductDto>> Get(ProductRequestModel requestModel)
        {
            var result = _productRepo.GetWithSpec(ProductSpecification.GetAll(requestModel));

            var product = _mapper.Map<List<ProductDto>>(result.data);

            return ResponseModel<List<ProductDto>>.Success(product);
        }

        public ResponseModel<ProductDto> GetById(Guid Id)
        {
            var result = _productRepo.GetEntityWithSpec(ProductSpecification.GetById(Id));

            if (result == null)
                throw new NotFoundException(Message.Error_NotFound);

            var product = _mapper.Map<ProductDto>(result);

            return ResponseModel<ProductDto>.Success(product);
        }

        public async Task<ResponseModel<ProductDto>> Create(CreateProductDto Dto)
        {
            var validationResult = await _createProductValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var product = _mapper.Map<Product>(Dto);

            await _productRepo.Add(product);
            await _productRepo.Save();

            return ResponseModel<ProductDto>.Success(_mapper.Map<ProductDto>(product));
        }

        public async Task<ResponseModel<ProductDto>> Update(UpdateProductDto Dto)
        {
            var validationResult = await _updateProductValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var product = await _productRepo.GetById(Dto.Id);

            product!.Update(Dto);

            _productRepo.Update(product);

            await _productRepo.Save();

            return ResponseModel<ProductDto>.Success(_mapper.Map<ProductDto>(product));
        }

        public async Task<ResponseModel<string>> Delete(Guid id)
        {
            var product = await _productRepo.GetById(id);

            if (product == null)
                throw new NotFoundException(Message.Error_NotFound);

            _productRepo.Delete(product);

            await _productRepo.Save();

            return ResponseModel<string>.Success();
        }
    }
}
