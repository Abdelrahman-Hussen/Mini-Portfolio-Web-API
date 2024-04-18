using Portfolio.Domain.Features.ReviewsSection.Dtos;

namespace Portfolio.Application.Features.ReviewsSection.Abstractions
{
    public interface IReviewService
    {
        Task<ResponseModel<ReviewDto>> Create(CreateReviewDto Dto);
        Task<ResponseModel<string>> Delete(Guid id);
        ResponseModel<List<ReviewDto>> Get(RequestModel requestModel);
        ResponseModel<ReviewDto> GetById(Guid Id);
        Task<ResponseModel<ReviewDto>> Update(UpdateReviewDto Dto);
    }
}