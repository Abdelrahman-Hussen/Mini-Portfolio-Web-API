using Portfolio.Application.Features.ReviewsSection.Abstractions;
using Portfolio.Application.Features.ReviewsSection.Specifications;
using Portfolio.Domain.Features.ReviewsSection.Dtos;
using Portfolio.Domain.Features.ReviewsSection.Models;

namespace Portfolio.Application.Features.ReviewsSection.Services
{
    internal class ReviewService(IMapper _mapper,
                                 IGenericRepository<Review> _reviewRepo,
                                 IValidator<CreateReviewDto> _createReviewValidation,
                                 IValidator<UpdateReviewDto> _updateReviewValidation) : IReviewService
    {
        public ResponseModel<List<ReviewDto>> Get(RequestModel requestModel)
        {
            var result = _reviewRepo.GetWithSpec(ReviewSpecification.GetAll(requestModel));

            var review = _mapper.Map<List<ReviewDto>>(result.data);

            return ResponseModel<List<ReviewDto>>.Success(review);
        }

        public ResponseModel<ReviewDto> GetById(Guid Id)
        {
            var result = _reviewRepo.GetEntityWithSpec(ReviewSpecification.GetById(Id));

            if (result == null)
                throw new NotFoundException(Message.Error_NotFound);

            var review = _mapper.Map<ReviewDto>(result);

            return ResponseModel<ReviewDto>.Success(review);
        }

        public async Task<ResponseModel<ReviewDto>> Create(CreateReviewDto Dto)
        {
            var validationResult = await _createReviewValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var review = _mapper.Map<Review>(Dto);

            await _reviewRepo.Add(review);
            await _reviewRepo.Save();

            return ResponseModel<ReviewDto>.Success(_mapper.Map<ReviewDto>(review));
        }

        public async Task<ResponseModel<ReviewDto>> Update(UpdateReviewDto Dto)
        {

            var validationResult = await _updateReviewValidation.ValidateAsync(Dto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var review = await _reviewRepo.GetById(Dto.Id);

            review!.Update(Dto);

            _reviewRepo.Update(review);

            await _reviewRepo.Save();

            return ResponseModel<ReviewDto>.Success(_mapper.Map<ReviewDto>(review));

        }

        public async Task<ResponseModel<string>> Delete(Guid id)
        {
            var review = await _reviewRepo.GetById(id);

            if (review == null)
                throw new NotFoundException(Message.Error_NotFound);

            _reviewRepo.Delete(review);

            await _reviewRepo.Save();

            return ResponseModel<string>.Success();
        }
    }
}
