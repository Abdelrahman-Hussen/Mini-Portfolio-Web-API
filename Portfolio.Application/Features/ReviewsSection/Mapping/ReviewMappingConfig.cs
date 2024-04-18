using Portfolio.Domain.Features.ReviewsSection.Dtos;
using Portfolio.Domain.Features.ReviewsSection.Models;
using Mapster;

namespace Portfolio.Application.Features.ReviewsSection.Mapping
{
    internal class ReviewMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Review, ReviewDto>()
                 .Map(dest => dest.ReviewerImage,
                    src => src.ReviewerImage.MappFile(FileHelper.Review));

            config.NewConfig<CreateReviewDto, Review>()
                 .Map(dest => dest.ReviewerImage,
                    src => FileHelper.Upload(src.ReviewerImage, FileHelper.Review));
        }
    }
}
