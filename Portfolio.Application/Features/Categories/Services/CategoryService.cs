using Portfolio.Application.Features.Categories.Abstractions;
using Portfolio.Application.Features.Categories.Specifications;
using Portfolio.Domain.Features.Categories.Dtos;
using Portfolio.Domain.Features.Categories.Models;

namespace Portfolio.Application.Features.Categories.Services
{
    internal class CategoryService(IMapper _mapper,
                                 IGenericRepository<Category> _categoryRepo,
                                 IValidator<CreateCategoryDto> _createCategoryValidation,
                                 IValidator<UpdateCategoryDto> _updateCategoryValidation) : ICategoryService
    {
        public ResponseModel<List<CategoryDto>> Get(RequestModel requestModel)
        {
            var result = _categoryRepo.GetWithSpec(CategorySpecification.GetAll(requestModel));

            var category = _mapper.Map<List<CategoryDto>>(result.data);

            return ResponseModel<List<CategoryDto>>.Success(category);
        }

        public ResponseModel<List<CategoryLookUpDto>> GetAsLookup()
        {
            var result = _categoryRepo.GetWithSpec(CategorySpecification.GetAll(new RequestModel()));

            var category = _mapper.Map<List<CategoryLookUpDto>>(result.data);

            return ResponseModel<List<CategoryLookUpDto>>.Success(category);
        }

        public ResponseModel<CategoryDto> GetById(Guid Id)
        {
            var result = _categoryRepo.GetEntityWithSpec(CategorySpecification.GetById(Id));

            if (result == null)
                throw new NotFoundException(Message.Error_NotFound);

            var category = _mapper.Map<CategoryDto>(result);

            return ResponseModel<CategoryDto>.Success(category);
        }

        public async Task<ResponseModel<CategoryDto>> Create(CreateCategoryDto Dto)
        {
            var validationResult = await _createCategoryValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var category = _mapper.Map<Category>(Dto);

            await _categoryRepo.Add(category);
            await _categoryRepo.Save();

            return ResponseModel<CategoryDto>.Success(_mapper.Map<CategoryDto>(category));
        }

        public async Task<ResponseModel<CategoryDto>> Update(UpdateCategoryDto Dto)
        {

            var validationResult = await _updateCategoryValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var category = await _categoryRepo.GetById(Dto.Id);

            category!.Update(Dto);

            _categoryRepo.Update(category);

            await _categoryRepo.Save();

            return ResponseModel<CategoryDto>.Success(_mapper.Map<CategoryDto>(category));

        }

        public async Task<ResponseModel<string>> Delete(Guid id)
        {
            var category = await _categoryRepo.GetById(id);

            if (category == null)
                throw new NotFoundException(Message.Error_NotFound);

            _categoryRepo.Delete(category);

            await _categoryRepo.Save();

            return ResponseModel<string>.Success();
        }
    }
}
