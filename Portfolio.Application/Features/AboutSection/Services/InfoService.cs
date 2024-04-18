using Portfolio.Application.Features.AboutSection.Abstractions;
using Portfolio.Application.Features.AboutSection.Specifications;
using Portfolio.Domain.Features.AboutSection.Dtos.Infos;
using Portfolio.Domain.Features.AboutSection.Models;

namespace Portfolio.Application.Features.AboutSection.Services
{
    internal class InfoService(IMapper _mapper,
                               IGenericRepository<Info> _infoRepo,
                               IValidator<CreateOrUpdateInfoDto> _createOrUpdateValidation) : IInfoService
    {
        public ResponseModel<InfoDto> Get()
        {
            var result = _infoRepo.GetEntityWithSpec(InfoSpecification.Get());

            if (result is null)
                throw new NotFoundException(Message.Error_NotFound);

            var info = _mapper.Map<InfoDto>(result);

            return ResponseModel<InfoDto>.Success(info);
        }

        public async Task<ResponseModel<InfoDto>> CreateOrUpdate(CreateOrUpdateInfoDto Dto)
        {
            var validationResult = await _createOrUpdateValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var result = _infoRepo.GetEntityWithSpec(InfoSpecification.Get());

            if (result is null)
            {
                var info = _mapper.Map<Info>(Dto);

                await _infoRepo.Add(_mapper.Map<Info>(Dto));
                await _infoRepo.Save();

                return ResponseModel<InfoDto>.Success(_mapper.Map<InfoDto>(info));
            }
            else
            {
                result.Update(Dto);
                await _infoRepo.Save();

                return ResponseModel<InfoDto>.Success(_mapper.Map<InfoDto>(result));
            }
        }
    }
}
