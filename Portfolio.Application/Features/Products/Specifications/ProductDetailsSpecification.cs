using Portfolio.Domain.Features.Products.Dtos.Details;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Specifications
{
    internal class ProductDetailsSpecification : BaseSpecification<ProductDetails>
    {
        public static ProductDetailsSpecification GetAll(ProductDetailsRequestModel requestModel)
        {
            var spec = new ProductDetailsSpecification();

            spec.AddCriteria(p => p.ProductId == requestModel.ProductId);

            if (requestModel.ApplyPagination)
                spec.ApplyPaging(PageSize: requestModel.PageSize, requestModel.PageIndex);

            return spec;
        }

        public static ProductDetailsSpecification GetById(Guid Id)
        {
            var spec = new ProductDetailsSpecification();

            spec.AddCriteria(x => x.Id == Id);

            return spec;
        }
    }
}