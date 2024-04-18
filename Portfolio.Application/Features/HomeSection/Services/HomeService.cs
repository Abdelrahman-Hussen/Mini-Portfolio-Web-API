using Portfolio.Application.Features.HomeSection.Abstractions;
using Portfolio.Application.Features.HomeSection.Specifications;
using Portfolio.Domain.Features.HomeSection.Dtos;
using Portfolio.Domain.Features.HomeSection.Models;

namespace Portfolio.Application.Features.HomeSection.Services
{
    internal class HomeService(IMapper _mapper,
                               IGenericRepository<Home> _homeRepo,
                               IValidator<CreateOrUpdateHomeDto> _createOrUpdateValidation) : IHomeService
    {
        public ResponseModel<HomeDto> Get()
        {
            var result = _homeRepo.GetEntityWithSpec(HomeSpecification.Get());

            if (result is null)
                throw new NotFoundException(Message.Error_NotFound);

            var home = _mapper.Map<HomeDto>(result);

            return ResponseModel<HomeDto>.Success(home);
        }

        public async Task<ResponseModel<HomeDto>> CreateOrUpdate(CreateOrUpdateHomeDto Dto)
        {
            var validationResult = await _createOrUpdateValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var result = _homeRepo.GetEntityWithSpec(HomeSpecification.Get());

            if (result is null)
            {
                var home = _mapper.Map<Home>(Dto);

                await _homeRepo.Add(_mapper.Map<Home>(Dto));
                await _homeRepo.Save();

                return ResponseModel<HomeDto>.Success(_mapper.Map<HomeDto>(home));
            }
            else
            {
                result.Update(Dto);
                await _homeRepo.Save();

                return ResponseModel<HomeDto>.Success(_mapper.Map<HomeDto>(result));
            }
        }
    }
}
