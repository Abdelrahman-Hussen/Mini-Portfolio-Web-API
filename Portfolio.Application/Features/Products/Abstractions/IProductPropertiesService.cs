using Portfolio.Domain.Features.Products.Dtos.Properties;

namespace Portfolio.Application.Features.Products.Abstractions
{
    public interface IProductPropertiesService
    {
        Task<ResponseModel<ProductPropertiesDto>> Create(CreateProductPropertiesDto Dto);
        Task<ResponseModel<string>> Delete(Guid id);
        ResponseModel<List<ProductPropertiesDto>> Get(ProductPropertiesRequestModel requestModel);
        ResponseModel<ProductPropertiesDto> GetById(Guid Id);
        Task<ResponseModel<ProductPropertiesDto>> Update(UpdateProductPropertiesDto Dto);
    }
}