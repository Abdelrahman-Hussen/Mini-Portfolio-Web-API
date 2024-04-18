using Portfolio.Domain.Features.Categories.Dtos;

namespace Portfolio.Application.Features.Categories.Abstractions
{
    public interface ICategoryService
    {
        Task<ResponseModel<CategoryDto>> Create(CreateCategoryDto Dto);
        Task<ResponseModel<string>> Delete(Guid id);
        ResponseModel<List<CategoryDto>> Get(RequestModel requestModel);
        ResponseModel<List<CategoryLookUpDto>> GetAsLookup();
        ResponseModel<CategoryDto> GetById(Guid Id);
        Task<ResponseModel<CategoryDto>> Update(UpdateCategoryDto Dto);
    }
}