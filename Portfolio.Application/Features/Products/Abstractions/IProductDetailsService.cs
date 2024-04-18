using Portfolio.Domain.Features.Products.Dtos.Details;

namespace Portfolio.Application.Features.Products.Abstractions
{
    public interface IProductDetailsService
    {
        Task<ResponseModel<ProductDetailsDto>> Create(CreateProductDetailsDto Dto);
        Task<ResponseModel<string>> Delete(Guid id);
        ResponseModel<List<ProductDetailsDto>> Get(ProductDetailsRequestModel requestModel);
        ResponseModel<ProductDetailsDto> GetById(Guid Id);
        Task<ResponseModel<ProductDetailsDto>> Update(UpdateProductDetailsDto Dto);
    }
}