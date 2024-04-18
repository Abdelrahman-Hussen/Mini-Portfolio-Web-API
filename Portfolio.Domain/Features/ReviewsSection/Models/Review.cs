using Portfolio.Common.Helpers;
using Portfolio.Domain.Features.ReviewsSection.Dtos;
using Microsoft.AspNetCore.Http;

namespace Portfolio.Domain.Features.ReviewsSection.Models
{
    public class Review : EntityWithId
    {
        public string ReviewerName { get; set; }
        public string ReviewerTitle { get; set; }
        public string ReviewerImage { get; set; }
        public string Content { get; set; }

        public void Update(UpdateReviewDto dto)
        {
            ReviewerName = String.IsNullOrWhiteSpace(dto.ReviewerName) ? ReviewerName : dto.ReviewerName;
            ReviewerTitle = String.IsNullOrWhiteSpace(dto.ReviewerTitle) ? ReviewerTitle : dto.ReviewerTitle;
            Content = String.IsNullOrWhiteSpace(dto.Content) ? Content : dto.Content;
            ReviewerImage = dto.ReviewerImage is not null ? UpdateImage(dto.ReviewerImage) : ReviewerImage;
            UpdatedAt = DateTime.UtcNow;
        }

        public string UpdateImage(IFormFile image)
        {
            if (ReviewerImage is not null)
                DeleteImage();

            return FileHelper.Upload(image, FileHelper.Review);
        }

        public void DeleteImage()
            => FileHelper.Delete(ReviewerImage, FileHelper.Review);

    }
}
