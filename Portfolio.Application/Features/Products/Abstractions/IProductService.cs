using Portfolio.Domain.Features.Products.Dtos.Products;

namespace Portfolio.Application.Features.Products.Abstractions
{
    public interface IProductService
    {
        Task<ResponseModel<ProductDto>> Create(CreateProductDto Dto);
        Task<ResponseModel<string>> Delete(Guid id);
        ResponseModel<List<ProductDto>> Get(ProductRequestModel requestModel);
        ResponseModel<ProductDto> GetById(Guid Id);
        Task<ResponseModel<ProductDto>> Update(UpdateProductDto Dto);
    }
}