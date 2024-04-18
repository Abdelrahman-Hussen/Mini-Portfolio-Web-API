using Microsoft.AspNetCore.Http;

namespace Portfolio.Domain.Features.ReviewsSection.Dtos
{
    public class CreateReviewDto
    {
        public string ReviewerName { get; set; }
        public string ReviewerTitle { get; set; }
        public IFormFile ReviewerImage { get; set; }
        public string Content { get; set; }
    }
}
