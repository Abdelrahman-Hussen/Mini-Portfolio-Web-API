using Portfolio.Domain.Features.Categories.Models;

namespace Portfolio.Application.Features.Categories.Specifications
{
    internal class CategorySpecification : BaseSpecification<Category>
    {
        public static CategorySpecification GetAll(RequestModel requestModel)
        {
            var spec = new CategorySpecification();

            if (requestModel.ApplyPagination)
                spec.ApplyPaging(PageSize: requestModel.PageSize, requestModel.PageIndex);

            return spec;
        }

        public static CategorySpecification GetById(Guid Id)
        {
            var spec = new CategorySpecification();

            spec.AddCriteria(x => x.Id == Id);

            return spec;
        }
    }
}
