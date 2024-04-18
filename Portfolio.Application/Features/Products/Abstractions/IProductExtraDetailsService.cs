using Portfolio.Domain.Features.Products.Dtos.ExtraDetails;

namespace Portfolio.Application.Features.Products.Abstractions
{
    public interface IProductExtraDetailsService
    {
        Task<ResponseModel<ProductExtraDetailsDto>> Create(CreateProductExtraDetailsDto Dto);
        Task<ResponseModel<string>> Delete(Guid id);
        ResponseModel<List<ProductExtraDetailsDto>> Get(ProductExtraDetailsRequestModel requestModel);
        ResponseModel<ProductExtraDetailsDto> GetById(Guid Id);
        Task<ResponseModel<ProductExtraDetailsDto>> Update(UpdateProductExtraDetailsDto Dto);
    }
}