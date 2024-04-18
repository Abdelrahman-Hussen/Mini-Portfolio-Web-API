namespace Portfolio.Domain.Features.ReviewsSection.Dtos
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewerTitle { get; set; }
        public string ReviewerImage { get; set; }
        public string Content { get; set; }
    }
}
