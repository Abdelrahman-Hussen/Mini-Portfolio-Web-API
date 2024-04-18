using Portfolio.Domain.Features.Products.Dtos.ExtraDetails;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Specifications
{
    internal class ProductExtraDetailsSpecification : BaseSpecification<ProductExtraDetails>
    {
        public static ProductExtraDetailsSpecification GetAll(ProductExtraDetailsRequestModel requestModel)
        {
            var spec = new ProductExtraDetailsSpecification();

            spec.AddCriteria(p => p.ProductId == requestModel.ProductId);

            if (requestModel.ApplyPagination)
                spec.ApplyPaging(PageSize: requestModel.PageSize, requestModel.PageIndex);

            return spec;
        }

        public static ProductExtraDetailsSpecification GetById(Guid Id)
        {
            var spec = new ProductExtraDetailsSpecification();

            spec.AddCriteria(x => x.Id == Id);

            return spec;
        }
    }
}