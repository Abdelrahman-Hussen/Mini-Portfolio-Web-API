using Portfolio.Domain.Features.Products.Dtos.Products;
using Portfolio.Domain.Features.Products.Models;

namespace Portfolio.Application.Features.Products.Specifications
{
    internal class ProductSpecification : BaseSpecification<Product>
    {
        public static ProductSpecification GetAll(ProductRequestModel requestModel)
        {
            var spec = new ProductSpecification();

            if (requestModel.CategoryId is not null)
                spec.AddCriteria(p => p.CategoryId == requestModel.CategoryId);

            if (requestModel.WithIncludes)
                spec.AddInclude(new List<string>()
                {
                    nameof(Product.Category),
                    nameof(Product.Properties),
                    nameof(Product.Details),
                    nameof(Product.ExtraDetails)
                });

            if (requestModel.ApplyPagination)
                spec.ApplyPaging(PageSize: requestModel.PageSize, requestModel.PageIndex);

            return spec;
        }

        public static ProductSpecification GetById(Guid Id)
        {
            var spec = new ProductSpecification();

            spec.AddCriteria(x => x.Id == Id);

            return spec;
        }
    }
}
