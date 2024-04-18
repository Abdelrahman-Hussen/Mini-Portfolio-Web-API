using Portfolio.Domain.Features.ReviewsSection.Models;

namespace Portfolio.Application.Features.ReviewsSection.Specifications
{
    internal class ReviewSpecification : BaseSpecification<Review>
    {
        public static ReviewSpecification GetAll(RequestModel requestModel)
        {
            var spec = new ReviewSpecification();

            if (!String.IsNullOrWhiteSpace(requestModel.Search))
                spec.AddCriteria(r => r.ReviewerName.ToLower().Contains(requestModel.Search.ToLower())
                || r.ReviewerTitle.ToLower().Contains(requestModel.Search.ToLower())
                || r.Content.ToLower().Contains(requestModel.Search.ToLower()));

            if (requestModel.ApplyPagination)
                spec.ApplyPaging(PageSize: requestModel.PageSize, requestModel.PageIndex);

            return spec;
        }

        public static ReviewSpecification GetById(Guid Id)
        {
            var spec = new ReviewSpecification();

            spec.AddCriteria(r => r.Id == Id);

            return spec;
        }
    }
}
