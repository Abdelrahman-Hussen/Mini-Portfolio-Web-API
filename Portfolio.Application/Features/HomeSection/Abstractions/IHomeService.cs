using Portfolio.Domain.Features.HomeSection.Dtos;

namespace Portfolio.Application.Features.HomeSection.Abstractions
{
    public interface IHomeService
    {
        Task<ResponseModel<HomeDto>> CreateOrUpdate(CreateOrUpdateHomeDto Dto);
        ResponseModel<HomeDto> Get();
    }
}